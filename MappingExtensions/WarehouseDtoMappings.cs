using RESTfulAPI.Core.Domain.Shipping;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.Warehouses;

namespace RESTfulAPI.MappingExtensions
{
    public static class WarehouseDtoMappings
    {
        public static WarehouseDto ToDto(this Warehouse warehouse)
        {
            return warehouse.MapTo<Warehouse, WarehouseDto>();
        }
    }
}
