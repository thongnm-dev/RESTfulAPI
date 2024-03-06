using RESTfulAPI.Core.Domain.Common;
using RESTfulAPI.Core.Domain.Customers;

namespace RESTfulAPI.DTO.Customers
{
    public class CustomerAttributeMappingDto
    {
        public Customer Customer { get; set; }
        public GenericAttribute Attribute { get; set; }
    }
}
