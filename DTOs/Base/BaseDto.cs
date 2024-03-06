using Newtonsoft.Json;

namespace RESTfulAPI.DTO.Base
{
    public abstract class BaseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
