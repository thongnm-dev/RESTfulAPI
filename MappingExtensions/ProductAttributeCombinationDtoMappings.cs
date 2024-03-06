using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.Products;

namespace RESTfulAPI.MappingExtensions
{
    public static class ProductAttributeCombinationDtoMappings
    {
        public static ProductAttributeCombinationDto ToDto(this ProductAttributeCombination productAttributeCombination)
        {
            return productAttributeCombination.MapTo<ProductAttributeCombination, ProductAttributeCombinationDto>();
        }
    }
}
