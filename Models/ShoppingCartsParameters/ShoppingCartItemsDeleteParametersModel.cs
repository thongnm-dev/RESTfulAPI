using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RESTfulAPI.DTOs.ShoppingCarts;
using RESTfulAPI.ModelBinders;

namespace RESTfulAPI.Models.ShoppingCartsParameters
{
    [ModelBinder(typeof(ParametersModelBinder<ShoppingCartItemsDeleteParametersModel>))]
    public class ShoppingCartItemsDeleteParametersModel
    {
        /// <summary>
        ///     A comma-separated list of shopping cart item ids to delete
        /// </summary>
        [JsonProperty("ids")]
        public List<int> Ids { get; set; }

        /// <summary>
        ///     Either ShoppingCartType.ShoppingCart or ShoppingCartType.WishList
        /// </summary>
        [JsonProperty("shopping_cart_type")]
        public ShoppingCartType? ShoppingCartType { get; set; }

        /// <summary>
        /// if null, delete all shopping cart items of current customer
        /// </summary>
        [JsonProperty("customer_id", Required = Required.AllowNull)]
        public int? CustomerId { get; set; }
    }
}
