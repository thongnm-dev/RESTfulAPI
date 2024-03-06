using Newtonsoft.Json;

namespace RESTfulAPI.DTO.Orders
{
    public class SingleOrderRootObject
    {
        [JsonProperty("order")]
        public OrderDto Order { get; set; }
    }
}
