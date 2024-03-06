using Newtonsoft.Json;
using RESTfulAPI.Attributes;

namespace RESTfulAPI.DTO.Images
{
    [ImageValidation]
    public class ImageDto
    {
        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("attachment")]
        public string Attachment { get; set; }

        [JsonIgnore]
        public byte[] Binary { get; set; }

        [JsonIgnore]
        public string MimeType { get; set; }
    }
}
