using RESTfulAPI.Core.Domain.Stores;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.Stores;

namespace RESTfulAPI.MappingExtensions
{
    public static class StoreDtoMappings
    {
        public static StoreDto ToDto(this Store store)
        {
            return store.MapTo<Store, StoreDto>();
        }
    }
}
