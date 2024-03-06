using Newtonsoft.Json;

namespace RESTfulAPI.DTO.SpecificationAttributes
{
    public class ProductSpecificationAttributesCountRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
