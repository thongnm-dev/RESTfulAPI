using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using RESTfulAPI.DTO.Manufacturers;
using RESTfulAPI.Helpers;

namespace RESTfulAPI.Validators
{
    [UsedImplicitly]
    public class ManufacturerDtoValidator : BaseDtoValidator<ManufacturerDto>
    {
        #region Constructors

        public ManufacturerDtoValidator(IHttpContextAccessor httpContextAccessor, IJsonHelper jsonHelper, Dictionary<string, object> requestJsonDictionary) :
            base(httpContextAccessor, jsonHelper, requestJsonDictionary)
        {
            SetNameRule();
        }

        #endregion

        #region Private Methods

        private void SetNameRule()
        {
            SetNotNullOrEmptyCreateOrUpdateRule(m => m.Name, "invalid name", "name");
        }

        #endregion
    }
}
