using RESTfulAPI.Core.Domain.Orders;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.Orders;

namespace RESTfulAPI.MappingExtensions
{
    public static class OrderDtoMappings
    {
        public static OrderDto ToDto(this Order order)
        {
            return order.MapTo<Order, OrderDto>();
        }
    }
}
