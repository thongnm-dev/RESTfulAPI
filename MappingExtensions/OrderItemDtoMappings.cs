using RESTfulAPI.Core.Domain.Orders;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.OrderItems;

namespace RESTfulAPI.MappingExtensions
{
    public static class OrderItemDtoMappings
    {
        public static OrderItemDto ToDto(this OrderItem orderItem)
        {
            return orderItem.MapTo<OrderItem, OrderItemDto>();
        }
    }
}
