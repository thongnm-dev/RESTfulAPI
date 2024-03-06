using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.ProductWarehouseIventories;

namespace RESTfulAPI.MappingExtensions
{
    public static class ProductWarehouseInventoryDtoMappings
    {
        public static ProductWarehouseInventoryDto ToDto(this ProductWarehouseInventory mapping)
        {
            return mapping.MapTo<ProductWarehouseInventory, ProductWarehouseInventoryDto>();
        }
    }
}
