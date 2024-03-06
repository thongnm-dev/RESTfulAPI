using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.ProductManufacturerMappings;

namespace RESTfulAPI.MappingExtensions
{
    public static class ProductManufacturerMappingDtoMappings
    {
        public static ProductManufacturerMappingsDto ToDto(this ProductManufacturer mapping)
        {
            return mapping.MapTo<ProductManufacturer, ProductManufacturerMappingsDto>();
        }
    }
}
