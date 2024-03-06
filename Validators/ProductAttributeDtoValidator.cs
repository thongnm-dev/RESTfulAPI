using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using RESTfulAPI.DTO.ProductAttributes;
using RESTfulAPI.Helpers;

namespace RESTfulAPI.Validators
{
    [UsedImplicitly]
    public class ProductAttributeDtoValidator : BaseDtoValidator<ProductAttributeDto>
    {
        #region Constructors

        public ProductAttributeDtoValidator(IHttpContextAccessor httpContextAccessor, IJsonHelper jsonHelper, Dictionary<string, object> requestJsonDictionary) :
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
