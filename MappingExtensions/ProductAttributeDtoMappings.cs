using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.ProductAttributes;

namespace RESTfulAPI.MappingExtensions
{
    public static class ProductAttributeDtoMappings
    {
        public static ProductAttributeDto ToDto(this ProductAttribute productAttribute)
        {
            return productAttribute.MapTo<ProductAttribute, ProductAttributeDto>();
        }
    }
}
