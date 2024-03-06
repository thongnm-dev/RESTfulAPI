using Newtonsoft.Json;

namespace RESTfulAPI.DTO.ProductManufacturerMappings
{
    public class ProductManufacturerMappingsCountRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
