using Newtonsoft.Json;

namespace RESTfulAPI.DTO.Customers
{
    public class CustomersCountRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
