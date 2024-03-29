﻿using System;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Orders;

namespace RESTfulAPI.Factories
{
    public class ShoppingCartItemFactory : IFactory<ShoppingCartItem>
    {
        public Task<ShoppingCartItem> InitializeAsync()
        {
            var newShoppingCartItem = new ShoppingCartItem();

            newShoppingCartItem.CreatedOnUtc = DateTime.UtcNow;
            newShoppingCartItem.UpdatedOnUtc = DateTime.UtcNow;

            return Task.FromResult(newShoppingCartItem);
        }
    }
}
