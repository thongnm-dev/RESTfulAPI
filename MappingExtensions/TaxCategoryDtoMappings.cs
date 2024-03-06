using RESTfulAPI.Core.Domain.Tax;
using RESTfulAPI.DTOs.Taxes;
using RESTfulAPI.AutoMapper;

namespace RESTfulAPI.MappingExtensions
{
    public static class TaxCategoryDtoMappings
    {
        public static TaxCategoryDto ToDto(this TaxCategory taxCategory)
        {
            return taxCategory.MapTo<TaxCategory, TaxCategoryDto>();
        }
    }
}
