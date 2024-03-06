using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.Core;
using RESTfulAPI.Core.Domain.Security;
using RESTfulAPI.Core.Domain.Stores;
using RESTfulAPI.DTO.Errors;
using RESTfulAPI.JSON.ActionResults;
using RESTfulAPI.JSON.Serializers;
using RESTfulAPI.Services.Customers;
using RESTfulAPI.Services.Discounts;
using RESTfulAPI.Services.Localization;
using RESTfulAPI.Services.Logging;
using RESTfulAPI.Services.Media;
using RESTfulAPI.Services.Security;
using RESTfulAPI.Services.Stores;
using RESTfulAPI.Web.Framework.Controllers;

namespace RESTfulAPI.Controllers
{
    [Authorize(Policy = JwtBearerDefaults.AuthenticationScheme, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class BaseApiController : Controller
    {
        protected readonly IAclService AclService;
        protected readonly ICustomerActivityService CustomerActivityService;
        protected readonly ICustomerService CustomerService;
        protected readonly IDiscountService DiscountService;
        protected readonly IJsonFieldsSerializer JsonFieldsSerializer;
        protected readonly ILocalizationService LocalizationService;
        protected readonly IPictureService PictureService;
        protected readonly IStoreMappingService StoreMappingService;
        protected readonly IStoreService StoreService;

        public BaseApiController(
            IJsonFieldsSerializer jsonFieldsSerializer,
            IAclService aclService,
            ICustomerService customerService,
            IStoreMappingService storeMappingService,
            IStoreService storeService,
            IDiscountService discountService,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            IPictureService pictureService)
        {
            JsonFieldsSerializer = jsonFieldsSerializer;
            AclService = aclService;
            CustomerService = customerService;
            StoreMappingService = storeMappingService;
            StoreService = storeService;
            DiscountService = discountService;
            CustomerActivityService = customerActivityService;
            LocalizationService = localizationService;
            PictureService = pictureService;
        }

        protected IActionResult Error(HttpStatusCode statusCode = (HttpStatusCode)422, string propertyKey = "", string errorMessage = "")
        {
            var errors = new Dictionary<string, List<string>>();

            if (!string.IsNullOrEmpty(errorMessage) && !string.IsNullOrEmpty(propertyKey))
            {
                var errorsList = new List<string>
                                 {
                                     errorMessage
                                 };
                errors.Add(propertyKey, errorsList);
            }

            foreach (var item in ModelState)
            {
                var errorMessages = item.Value.Errors.Select(x => x.ErrorMessage);

                var validErrorMessages = new List<string>();

                validErrorMessages.AddRange(errorMessages.Where(message => !string.IsNullOrEmpty(message)));

                if (validErrorMessages.Count > 0)
                {
                    if (errors.ContainsKey(item.Key))
                    {
                        errors[item.Key].AddRange(validErrorMessages);
                    }
                    else
                    {
                        errors.Add(item.Key, validErrorMessages.ToList());
                    }
                }
            }

            var errorsRootObject = new ErrorsRootObject
            {
                Errors = errors
            };

            var errorsJson = JsonFieldsSerializer.Serialize(errorsRootObject, null);

            return new ErrorActionResult(errorsJson, statusCode);
        }

        protected IActionResult AccessDenied()
        {
            return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status403Forbidden);
        }

        protected async Task UpdateAclRolesAsync<TEntity>(TEntity entity, List<int> passedRoleIds) where TEntity : BaseEntity, IAclSupported
        {
            if (passedRoleIds == null)
            {
                return;
            }

            entity.SubjectToAcl = passedRoleIds.Any();

            var existingAclRecords = await AclService.GetAclRecordsAsync(entity);
            var allCustomerRoles = await CustomerService.GetAllCustomerRolesAsync(true);
            foreach (var customerRole in allCustomerRoles)
            {
                if (passedRoleIds.Contains(customerRole.Id))
                {
                    //new role
                    if (existingAclRecords.Count(acl => acl.CustomerRoleId == customerRole.Id) == 0)
                    {
                        await AclService.InsertAclRecordAsync(entity, customerRole.Id);
                    }
                }
                else
                {
                    //remove role
                    var aclRecordToDelete = existingAclRecords.FirstOrDefault(acl => acl.CustomerRoleId == customerRole.Id);
                    if (aclRecordToDelete != null)
                    {
                        await AclService.DeleteAclRecordAsync(aclRecordToDelete);
                    }
                }
            }
        }

        protected async Task UpdateStoreMappingsAsync<TEntity>(TEntity entity, List<int> passedStoreIds) where TEntity : BaseEntity, IStoreMappingSupported
        {
            if (passedStoreIds == null)
            {
                return;
            }

            entity.LimitedToStores = passedStoreIds.Any();

            var existingStoreMappings = await StoreMappingService.GetStoreMappingsAsync(entity);
            var allStores = await StoreService.GetAllStoresAsync();
            foreach (var store in allStores)
            {
                if (passedStoreIds.Contains(store.Id))
                {
                    //new store
                    if (existingStoreMappings.Count(sm => sm.StoreId == store.Id) == 0)
                    {
                        await StoreMappingService.InsertStoreMappingAsync(entity, store.Id);
                    }
                }
                else
                {
                    //remove store
                    var storeMappingToDelete = existingStoreMappings.FirstOrDefault(sm => sm.StoreId == store.Id);
                    if (storeMappingToDelete != null)
                    {
                        await StoreMappingService.DeleteStoreMappingAsync(storeMappingToDelete);
                    }
                }
            }
        }
    }
}
