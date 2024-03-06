using RESTfulAPI.Core.Domain.Directory;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO;
using RESTfulAPI.DTOs.StateProvinces;

namespace RESTfulAPI.MappingExtensions
{
    public static class StateProvinceDtoMappings
    {
        public static StateProvinceDto ToDto(this StateProvince address)
        {
            return address.MapTo<StateProvince, StateProvinceDto>();
        }

        public static StateProvince ToEntity(this StateProvinceDto address)
        {
            return address.MapTo<StateProvinceDto, StateProvince>();
        }
    }
}
