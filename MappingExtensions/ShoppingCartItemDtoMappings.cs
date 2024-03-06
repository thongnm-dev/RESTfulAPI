using RESTfulAPI.Core.Domain.Orders;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.ShoppingCarts;

namespace RESTfulAPI.MappingExtensions
{
    public static class ShoppingCartItemDtoMappings
    {
        public static ShoppingCartItemDto ToDto(this ShoppingCartItem shoppingCartItem)
        {
            return shoppingCartItem.MapTo<ShoppingCartItem, ShoppingCartItemDto>();
        }
    }
}
