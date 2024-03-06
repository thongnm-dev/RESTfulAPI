using Newtonsoft.Json;
using RESTfulAPI.DTO.Base;

namespace RESTfulAPI.DTO
{
    [JsonObject(Title = "attribute")]
    public class ProductItemAttributeDto : BaseDto
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
