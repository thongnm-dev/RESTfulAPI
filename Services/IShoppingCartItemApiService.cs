using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Orders;
using RESTfulAPI.Infrastructure;

namespace RESTfulAPI.Services
{
    public interface IShoppingCartItemApiService
    {
        List<ShoppingCartItem> GetShoppingCartItems(
            int? customerId = null, DateTime? createdAtMin = null, DateTime? createdAtMax = null,
            DateTime? updatedAtMin = null, DateTime? updatedAtMax = null, int? limit = null,
            int? page = null, ShoppingCartType? shoppingCartType = null);

        Task<ShoppingCartItem> GetShoppingCartItemAsync(int id);
    }
}
