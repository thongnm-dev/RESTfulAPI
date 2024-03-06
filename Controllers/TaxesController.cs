using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.Core.Domain.Tax;
using RESTfulAPI.Attributes;
using RESTfulAPI.Authorization.Attributes;
using RESTfulAPI.Delta;
using RESTfulAPI.DTO.Errors;
using RESTfulAPI.DTOs.Taxes;
using RESTfulAPI.Factories;
using RESTfulAPI.Helpers;
using RESTfulAPI.JSON.ActionResults;
using RESTfulAPI.JSON.Serializers;
using RESTfulAPI.ModelBinders;
using RESTfulAPI.Services.Customers;
using RESTfulAPI.Services.Discounts;
using RESTfulAPI.Services.Localization;
using RESTfulAPI.Services.Logging;
using RESTfulAPI.Services.Media;
using RESTfulAPI.Services.Security;
using RESTfulAPI.Services.Stores;
using RESTfulAPI.Services.Tax;

namespace RESTfulAPI.Controllers
{
    [AuthorizePermission("ManageTaxSettings")]
    public class TaxesController : BaseApiController
    {
        private readonly ITaxCategoryService _taxCategoryService;
        private readonly IDTOHelper _dtoHelper;

        public TaxesController(
           IJsonFieldsSerializer jsonFieldsSerializer,
           IAclService aclService,
           ICustomerService customerService,
           IStoreMappingService storeMappingService,
           IStoreService storeService,
           IDiscountService discountService,
           ICustomerActivityService customerActivityService,
           ILocalizationService localizationService,
           IPictureService pictureService,
           ITaxCategoryService taxCategoryService, IDTOHelper dtoHelper) : base(jsonFieldsSerializer,
                  aclService,
                  customerService,
                  storeMappingService,
                  storeService,
                  discountService,
                  customerActivityService,
                  localizationService,
                  pictureService)
        {

            _taxCategoryService = taxCategoryService;
            _dtoHelper = dtoHelper;
        }

        [HttpGet]
        [Route("/api/taxcategories", Name = "getTaxCategories")]
        [ProducesResponseType(typeof(TaxCategoriesRootObject), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        [GetRequestsErrorInterceptorActionFilter]
        public async Task<IActionResult> getAllTaxCategories([FromQuery] string fields = "", [FromQuery] int? limit = 250)
        {
            var allTaxes = await _taxCategoryService.GetAllTaxCategoriesAsync();

            IList<TaxCategoryDto> taxCategoryDtos = new List<TaxCategoryDto>();

            foreach (var tax in allTaxes)
            {
                var taxDto = _dtoHelper.prepareTaxCategoryDto(tax);
                taxCategoryDtos.Add(taxDto);
            }

            var taxRoot = new TaxCategoriesRootObject
            {
                Taxes = taxCategoryDtos
            };

            var json = JsonFieldsSerializer.Serialize(taxRoot, fields);
            return new RawJsonActionResult(json);
        }

        [HttpPost]
        [Route("/api/taxCategories", Name = "createTaxCategory")]
        [ProducesResponseType(typeof(TaxCategoriesRootObject), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorsRootObject), 422)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CreateTaxCategory(
            [FromBody]
            [ModelBinder(typeof(JsonModelBinder<TaxCategoryDto>))]
            Delta<TaxCategoryDto> taxCategoryDelta)
        {
            // Here we display the errors if the validation has failed at some point.
            if (!ModelState.IsValid)
            {
                return Error();
            }

            var taxCategory = new TaxCategory();
            taxCategory.Name = taxCategoryDelta.Dto.Name;
            taxCategory.DisplayOrder = taxCategoryDelta.Dto.DisplayOrder;

            await _taxCategoryService.InsertTaxCategoryAsync(taxCategory);

            var newTaxCategoryDto =  _dtoHelper.prepareTaxCategoryDto(taxCategory);

            var root = new TaxCategoriesRootObject();
            root.Taxes.Add(newTaxCategoryDto);
            var json = JsonFieldsSerializer.Serialize(root, string.Empty);
            return new RawJsonActionResult(json);
        }

        [HttpDelete]
        [Route("/api/taxCategories/{id}", Name = "DeleteTaxCategory")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
        [GetRequestsErrorInterceptorActionFilter]
        public async Task<IActionResult> DeleteTax([FromRoute] int id)
        {
            if (id <= 0)
            {
                return Error(HttpStatusCode.BadRequest, "id", "invalid id");
            }

            var taxToDelete = await _taxCategoryService.GetTaxCategoryByIdAsync(id);

            if (taxToDelete == null)
            {
                return Error(HttpStatusCode.NotFound, "tax", "tax not found");
            }

            await _taxCategoryService.DeleteTaxCategoryAsync(taxToDelete);

            await CustomerActivityService.InsertActivityAsync("DeleteTaxCategory", await LocalizationService.GetResourceAsync("ActivityLog.DeleteTaxCategory"), taxToDelete);

            return new RawJsonActionResult("{}");
        }

    }
}
