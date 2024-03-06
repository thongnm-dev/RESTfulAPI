using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using RESTfulAPI.DTO.Categories;
using RESTfulAPI.Helpers;

namespace RESTfulAPI.Validators
{
    [UsedImplicitly]
    public class CategoryDtoValidator : BaseDtoValidator<CategoryDto>
    {
        #region Constructors

        public CategoryDtoValidator(IHttpContextAccessor httpContextAccessor, IJsonHelper jsonHelper, Dictionary<string, object> requestJsonDictionary) :
            base(httpContextAccessor, jsonHelper, requestJsonDictionary)
        {
            SetNameRule();
        }

        #endregion

        #region Private Methods

        private void SetNameRule()
        {
            SetNotNullOrEmptyCreateOrUpdateRule(c => c.Name, "invalid name", "name");
        }

        #endregion
    }
}
