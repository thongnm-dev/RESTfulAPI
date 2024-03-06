using RESTfulAPI.Core.Domain.Customers;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.CustomerRoles;

namespace RESTfulAPI.MappingExtensions
{
    public static class CustomerRoleDtoMappings
    {
        public static CustomerRoleDto ToDto(this CustomerRole customerRole)
        {
            return customerRole.MapTo<CustomerRole, CustomerRoleDto>();
        }
    }
}
