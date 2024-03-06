using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.Core.Domain.Shipping;
using RESTfulAPI.Attributes;
using RESTfulAPI.Authorization.Attributes;
using RESTfulAPI.Delta;
using RESTfulAPI.DTO.Errors;
using RESTfulAPI.DTO.Warehouses;
using RESTfulAPI.Factories;
using RESTfulAPI.Helpers;
using RESTfulAPI.Infrastructure;
using RESTfulAPI.JSON.ActionResults;
using RESTfulAPI.JSON.Serializers;
using RESTfulAPI.MappingExtensions;
using RESTfulAPI.ModelBinders;
using RESTfulAPI.Models.WarehousesParameters;
using RESTfulAPI.Services;
using RESTfulAPI.Services.Common;
using RESTfulAPI.Services.Customers;
using RESTfulAPI.Services.Discounts;
using RESTfulAPI.Services.Localization;
using RESTfulAPI.Services.Logging;
using RESTfulAPI.Services.Media;
using RESTfulAPI.Services.Security;
using RESTfulAPI.Services.Shipping;
using RESTfulAPI.Services.Stores;

namespace RESTfulAPI.Controllers
{
    public class WarehousesController : BaseApiController
    {
        private readonly IWarehouseApiService _warehouseApiService;
        private readonly IShippingService _shippingService;
        private readonly IAddressService _addressService;
        private readonly IDTOHelper _dtoHelper;
        private readonly IFactory<Warehouse> _factory;

        public WarehousesController(
            IWarehouseApiService warehouseApiService,
            IShippingService shippingService,
            IAddressService addressService,
            IJsonFieldsSerializer jsonFieldsSerializer,
            IAclService aclService,
            ICustomerService customerService,
            IStoreMappingService storeMappingService,
            IStoreService storeService,
            IDiscountService discountService,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            IPictureService pictureService,
            IDTOHelper dtoHelper,
            IFactory<Warehouse> factory) : base(jsonFieldsSerializer,
            aclService, customerService, storeMappingService, storeService, discountService, customerActivityService,
            localizationService, pictureService)
        {
            _warehouseApiService = warehouseApiService;
            _shippingService = shippingService;
            _addressService = addressService;
            _dtoHelper = dtoHelper;
            _factory = factory;
        }

        /// <summary>
        ///     Receive a list of all Warehouses
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        [Route("/api/warehouses", Name = "GetWarehouses")]
        [AuthorizePermission("ManageShippingSettings")]
        [ProducesResponseType(typeof(WarehousesRootObject), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        [GetRequestsErrorInterceptorActionFilter]
        public async Task<IActionResult> GetWarehouses([FromQuery] WarehousesParametersModel parameters)
        {
            //if (parameters.Limit < Constants.Configurations.MinLimit || parameters.Limit > Constants.Configurations.MaxLimit)
            //{
            //    return Error(HttpStatusCode.BadRequest, "limit", "Invalid limit parameter");
            //}

            //if (parameters.Page < Constants.Configurations.DefaultPageValue)
            //{
            //    return Error(HttpStatusCode.BadRequest, "page", "Invalid page parameter");
            //}

            var allWarehouses = _warehouseApiService.GetWarehouses(parameters.Ids, parameters.ProductId);

            IList<WarehouseDto> warehousesAsDtos = await allWarehouses
                .SelectAwait(async warehouse => await _dtoHelper.PrepareWarehouseDtoAsync(warehouse)).ToListAsync();

            var warehousesRootObject = new WarehousesRootObject
            {
                Warehouses = warehousesAsDtos
            };

            var json = JsonFieldsSerializer.Serialize(warehousesRootObject, parameters.Fields);

            return new RawJsonActionResult(json);
        }

        /// <summary>
        ///     Retrieve warehouse by specified id
        /// </summary>
        /// <param name="id">Id of the warehouse</param>
        /// <param name="fields">Fields from the warehouse you want your json to contain</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        [Route("/api/warehouses/{id}", Name = "GetWarehouseById")]
        [AuthorizePermission("ManageShippingSettings")]
        [ProducesResponseType(typeof(WarehousesRootObject), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
        [GetRequestsErrorInterceptorActionFilter]
        public async Task<IActionResult> GetWarehouseById([FromRoute] int id, [FromQuery] string fields = "")
        {
            if (id <= 0)
            {
                return Error(HttpStatusCode.BadRequest, "id", "invalid id");
            }

            var warehouse = _warehouseApiService.GetWarehouseById(id);

            if (warehouse == null)
            {
                return Error(HttpStatusCode.NotFound, "warehouse", "warehouse not found");
            }

            var warehouseDto = await _dtoHelper.PrepareWarehouseDtoAsync(warehouse);

            var warehousesRootObject = new WarehousesRootObject();

            warehousesRootObject.Warehouses.Add(warehouseDto);

            var json = JsonFieldsSerializer.Serialize(warehousesRootObject, fields);

            return new RawJsonActionResult(json);
        }

        [HttpPost]
        [Route("/api/warehouses", Name = "CreateWarehouse")]
        [AuthorizePermission("ManageShippingSettings")]
        [ProducesResponseType(typeof(WarehousesRootObject), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorsRootObject), 422)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CreateWarehouse(
            [FromBody]
            [ModelBinder(typeof(JsonModelBinder<WarehouseDto>))]
            Delta<WarehouseDto> warehouseDelta)
        {
            // Here we display the errors if the validation has failed at some point.
            if (!ModelState.IsValid)
            {
                return Error();
            }

            // Inserting the new warehouse
            var warehouse = await _factory.InitializeAsync();

            var address = warehouseDelta.Dto.Address.ToEntity();
            if (address.Id == 0)
            {
                await _addressService.InsertAddressAsync(address);
            }
            else
            {
                await _addressService.UpdateAddressAsync(address);
            }
            warehouse.AddressId = address.Id;

            warehouseDelta.Merge(warehouse);

            await _shippingService.InsertWarehouseAsync(warehouse);

            await CustomerActivityService.InsertActivityAsync("AddNewWarehouse",
                                                   await LocalizationService.GetResourceAsync("ActivityLog.AddNewWarehouse"), warehouse);

            // Preparing the result dto of the new category
            var newWarehouseDto = await _dtoHelper.PrepareWarehouseDtoAsync(warehouse);

            var warehousesRootObject = new WarehousesRootObject();

            warehousesRootObject.Warehouses.Add(newWarehouseDto);

            var json = JsonFieldsSerializer.Serialize(warehousesRootObject, string.Empty);

            return new RawJsonActionResult(json);
        }

        [HttpPut]
        [Route("/api/warehouses/{id}", Name = "UpdateWarehouse")]
        [AuthorizePermission("ManageShippingSettings")]
        [ProducesResponseType(typeof(WarehousesRootObject), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorsRootObject), 422)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateWarehouse(
            [FromBody]
            [ModelBinder(typeof(JsonModelBinder<WarehouseDto>))]
            Delta<WarehouseDto> warehouseDelta)
        {
            // Here we display the errors if the validation has failed at some point.
            if (!ModelState.IsValid)
            {
                return Error();
            }

            var warehouse = _warehouseApiService.GetWarehouseById(warehouseDelta.Dto.Id);

            if (warehouse == null)
            {
                return Error(HttpStatusCode.NotFound, "warehouse", "warehouse not found");
            }

            var address = warehouseDelta.Dto.Address.ToEntity();
            if (address.Id == 0)
            {
                await _addressService.InsertAddressAsync(address);
            }
            else
            {
                await _addressService.UpdateAddressAsync(address);
            }
            warehouse.AddressId = address.Id;

            warehouseDelta.Merge(warehouse);

            await _shippingService.UpdateWarehouseAsync(warehouse);

            await CustomerActivityService.InsertActivityAsync("UpdateWarehouse",
                                                   await LocalizationService.GetResourceAsync("ActivityLog.UpdateWarehouse"), warehouse);

            var warehouseDto = await _dtoHelper.PrepareWarehouseDtoAsync(warehouse);

            var warehousesRootObject = new WarehousesRootObject();

            warehousesRootObject.Warehouses.Add(warehouseDto);

            var json = JsonFieldsSerializer.Serialize(warehousesRootObject, string.Empty);

            return new RawJsonActionResult(json);
        }

        [HttpDelete]
        [Route("/api/warehouses/{id}", Name = "DeleteWarehouse")]
        [AuthorizePermission("ManageShippingSettings")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
        [GetRequestsErrorInterceptorActionFilter]
        public async Task<IActionResult> DeleteWarehouse([FromRoute] int id)
        {
            if (id <= 0)
            {
                return Error(HttpStatusCode.BadRequest, "id", "invalid id");
            }

            var warehouseToDelete = _warehouseApiService.GetWarehouseById(id);

            if (warehouseToDelete == null)
            {
                return Error(HttpStatusCode.NotFound, "warehouse", "warehouse not found");
            }

            await _shippingService.DeleteWarehouseAsync(warehouseToDelete);

            //activity log
            await CustomerActivityService.InsertActivityAsync("DeleteWarehouse", await LocalizationService.GetResourceAsync("ActivityLog.DeleteWarehouse"), warehouseToDelete);

            return new RawJsonActionResult("{}");
        }
    }
}
