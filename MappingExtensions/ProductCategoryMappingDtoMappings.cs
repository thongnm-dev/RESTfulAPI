using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.ProductCategoryMappings;

namespace RESTfulAPI.MappingExtensions
{
    public static class ProductCategoryMappingDtoMappings
    {
        public static ProductCategoryMappingDto ToDto(this ProductCategory mapping)
        {
            return mapping.MapTo<ProductCategory, ProductCategoryMappingDto>();
        }
    }
}
