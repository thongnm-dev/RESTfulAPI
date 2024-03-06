using Newtonsoft.Json;

namespace RESTfulAPI.DTO.Categories
{
    public class CategoriesCountRootObject
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
