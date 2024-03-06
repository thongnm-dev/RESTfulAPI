using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.Core;
using RESTfulAPI.Attributes;
using RESTfulAPI.Authorization.Attributes;
using RESTfulAPI.DTO.Errors;
using RESTfulAPI.DTO.Stores;
using RESTfulAPI.Helpers;
using RESTfulAPI.JSON.ActionResults;
using RESTfulAPI.JSON.Serializers;
using RESTfulAPI.Services.Customers;
using RESTfulAPI.Services.Discounts;
using RESTfulAPI.Services.Localization;
using RESTfulAPI.Services.Logging;
using RESTfulAPI.Services.Media;
using RESTfulAPI.Services.Security;
using RESTfulAPI.Services.Stores;

namespace RESTfulAPI.Controllers
{
    [AuthorizePermission("ManageStores")]
    public class StoreController : BaseApiController
    {
        private readonly IDTOHelper _dtoHelper;
        private readonly IStoreContext _storeContext;

        public StoreController(
            IJsonFieldsSerializer jsonFieldsSerializer,
            IAclService aclService,
            ICustomerService customerService,
            IStoreMappingService storeMappingService,
            IStoreService storeService,
            IDiscountService discountService,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            IPictureService pictureService,
            IStoreContext storeContext,
            IDTOHelper dtoHelper)
            : base(jsonFieldsSerializer,
                   aclService,
                   customerService,
                   storeMappingService,
                   storeService,
                   discountService,
                   customerActivityService,
                   localizationService,
                   pictureService)
        {
            _storeContext = storeContext;
            _dtoHelper = dtoHelper;
        }

        /// <summary>
        ///     Retrieve current store.
        /// </summary>
        /// <param name="fields">Fields you want your json to contain</param>
        [HttpGet]
        [Route("/api/stores/current", Name = "GetCurrentStore")]
        [AuthorizePermission("ManageStores", ignore: true)] // turn off all permission authorizations, access to this action is allowed to all authenticated customers
        [ProducesResponseType(typeof(StoresRootObject), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        [GetRequestsErrorInterceptorActionFilter]
        public async Task<IActionResult> GetCurrentStore([FromQuery] string fields = "")
        {
            var store = _storeContext.GetCurrentStore();

            if (store == null)
            {
                return Error(HttpStatusCode.NotFound, "store", "store not found");
            }

            var storeDto = await _dtoHelper.PrepareStoreDTOAsync(store);

            var storesRootObject = new StoresRootObject();

            storesRootObject.Stores.Add(storeDto);

            var json = JsonFieldsSerializer.Serialize(storesRootObject, fields);

            return new RawJsonActionResult(json);
        }

        /// <summary>
        ///     Retrieve all stores
        /// </summary>
        /// <param name="fields">Fields you want your json to contain</param>
        [HttpGet]
        [Route("/api/stores", Name = "GetAllStores")]
        [ProducesResponseType(typeof(StoresRootObject), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        [GetRequestsErrorInterceptorActionFilter]
        public async Task<IActionResult> GetAllStores([FromQuery] string fields = "")
        {
            var allStores = await StoreService.GetAllStoresAsync();

            IList<StoreDto> storesAsDto = new List<StoreDto>();

            foreach (var store in allStores)
            {
                var storeDto = await _dtoHelper.PrepareStoreDTOAsync(store);

                storesAsDto.Add(storeDto);
            }

            var storesRootObject = new StoresRootObject
            {
                Stores = storesAsDto
            };

            var json = JsonFieldsSerializer.Serialize(storesRootObject, fields);

            return new RawJsonActionResult(json);
        }
    }
}
