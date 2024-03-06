using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using RESTfulAPI.DTO.Products;
using RESTfulAPI.Helpers;

namespace RESTfulAPI.Validators
{
    [UsedImplicitly]
    public class ProductDtoValidator : BaseDtoValidator<ProductDto>
    {
        #region Constructors

        public ProductDtoValidator(IHttpContextAccessor httpContextAccessor, IJsonHelper jsonHelper, Dictionary<string, object> requestJsonDictionary) :
            base(httpContextAccessor, jsonHelper, requestJsonDictionary)
        {
            SetNameRule();
        }

        #endregion

        #region Private Methods

        private void SetNameRule()
        {
            SetNotNullOrEmptyCreateOrUpdateRule(p => p.Name, "invalid name", "name");
        }

        #endregion
    }
}
