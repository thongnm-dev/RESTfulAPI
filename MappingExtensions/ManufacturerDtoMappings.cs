using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.Manufacturers;

namespace RESTfulAPI.MappingExtensions
{
    public static class ManufacturerDtoMappings
    {
        public static ManufacturerDto ToDto(this Manufacturer manufacturer)
        {
            return manufacturer.MapTo<Manufacturer, ManufacturerDto>();
        }
    }
}
