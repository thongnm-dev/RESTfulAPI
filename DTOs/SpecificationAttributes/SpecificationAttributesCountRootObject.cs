using Newtonsoft.Json;

namespace RESTfulAPI.DTO.SpecificationAttributes
{
    public class SpecificationAttributesCountRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
