using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.Attributes;
using RESTfulAPI.Authorization.Attributes;
using RESTfulAPI.DTO.CustomerRoles;
using RESTfulAPI.DTO.Errors;
using RESTfulAPI.JSON.ActionResults;
using RESTfulAPI.JSON.Serializers;
using RESTfulAPI.MappingExtensions;
using RESTfulAPI.Services.Customers;
using RESTfulAPI.Services.Discounts;
using RESTfulAPI.Services.Localization;
using RESTfulAPI.Services.Logging;
using RESTfulAPI.Services.Media;
using RESTfulAPI.Services.Security;
using RESTfulAPI.Services.Stores;

namespace RESTfulAPI.Controllers
{
    public class CustomerRolesController : BaseApiController
    {
        public CustomerRolesController(
            IJsonFieldsSerializer jsonFieldsSerializer,
            IAclService aclService,
            ICustomerService customerService,
            IStoreMappingService storeMappingService,
            IStoreService storeService,
            IDiscountService discountService,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            IPictureService pictureService)
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
        }

        /// <summary>
        ///     Retrieve all customer roles
        /// </summary>
        /// <param name="fields">Fields from the customer role you want your json to contain</param>
        /// <response code="200">OK</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        [Route("/api/customer_roles", Name = "GetAllCustomerRoles")]
        [AuthorizePermission("ManageCustomers")]
        [ProducesResponseType(typeof(CustomerRolesRootObject), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
        [GetRequestsErrorInterceptorActionFilter]
        public async Task<IActionResult> GetAllCustomerRoles([FromQuery] string fields = "")
        {
            var allCustomerRoles = await CustomerService.GetAllCustomerRolesAsync();

            IList<CustomerRoleDto> customerRolesAsDto = allCustomerRoles.Select(role => role.ToDto()).ToList();

            var customerRolesRootObject = new CustomerRolesRootObject
            {
                CustomerRoles = customerRolesAsDto
            };

            var json = JsonFieldsSerializer.Serialize(customerRolesRootObject, fields);

            return new RawJsonActionResult(json);
        }
    }
}
