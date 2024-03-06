using RESTfulAPI.Core.Domain.Customers;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.Customers;

namespace RESTfulAPI.MappingExtensions
{
    public static class CustomerDtoMappings
    {
        public static CustomerDto ToDto(this Customer customer)
        {
            return customer.MapTo<Customer, CustomerDto>();
        }
    }
}
