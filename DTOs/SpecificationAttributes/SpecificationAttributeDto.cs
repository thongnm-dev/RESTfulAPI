using System.Collections.Generic;
using Newtonsoft.Json;
using RESTfulAPI.DTO.Base;

namespace RESTfulAPI.DTO.SpecificationAttributes
{
    [JsonObject(Title = "specification_attribute")]
    //[Validator(typeof(SpecificationAttributeDtoValidator))]
    public class SpecificationAttributeDto : BaseDto
    {
        /// <summary>
        ///     Gets or sets the name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the display order
        /// </summary>
        [JsonProperty("display_order")]
        public int DisplayOrder { get; set; }

        /// <summary>
        ///     Gets or sets the specification attribute options
        /// </summary>
        [JsonProperty("specification_attribute_options")]
        public List<SpecificationAttributeOptionDto> SpecificationAttributeOptions { get; set; }
    }
}
