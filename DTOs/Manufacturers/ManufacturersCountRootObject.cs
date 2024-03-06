using Newtonsoft.Json;

namespace RESTfulAPI.DTO.Manufacturers
{
    public class ManufacturersCountRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
