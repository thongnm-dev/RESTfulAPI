using Newtonsoft.Json;

namespace RESTfulAPI.DTO.Orders
{
    public class OrdersCountRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
