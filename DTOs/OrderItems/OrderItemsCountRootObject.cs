using Newtonsoft.Json;

namespace RESTfulAPI.DTO.OrderItems
{
    public class OrderItemsCountRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
