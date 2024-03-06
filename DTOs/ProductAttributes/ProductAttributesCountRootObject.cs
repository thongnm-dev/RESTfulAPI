using Newtonsoft.Json;

namespace RESTfulAPI.DTO.ProductAttributes
{
    public class ProductAttributesCountRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
