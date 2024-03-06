using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using RESTfulAPI.DTO.ProductCategoryMappings;
using RESTfulAPI.Helpers;

namespace RESTfulAPI.Validators
{
    [UsedImplicitly]
    public class ProductCategoryMappingDtoValidator : BaseDtoValidator<ProductCategoryMappingDto>
    {
        #region Constructors

        public ProductCategoryMappingDtoValidator(
            IHttpContextAccessor httpContextAccessor, IJsonHelper jsonHelper, Dictionary<string, object> requestJsonDictionary) : base(httpContextAccessor,
                                                                                                                                       jsonHelper,
                                                                                                                                       requestJsonDictionary)
        {
            SetCategoryIdRule();
            SetProductIdRule();
        }

        #endregion

        #region Private Methods

        private void SetCategoryIdRule()
        {
            SetGreaterThanZeroCreateOrUpdateRule(p => p.CategoryId, "invalid category_id", "category_id");
        }

        private void SetProductIdRule()
        {
            SetGreaterThanZeroCreateOrUpdateRule(p => p.ProductId, "invalid product_id", "product_id");
        }

        #endregion
    }
}
