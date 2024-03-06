using System;
using Newtonsoft.Json;

namespace RESTfulAPI.DTO.Products
{
    public class ProductsCountRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }

    }
}
