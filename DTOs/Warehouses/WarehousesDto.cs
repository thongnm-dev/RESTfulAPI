using Newtonsoft.Json;
using RESTfulAPI.DTO.Base;

namespace RESTfulAPI.DTO.Warehouses
{
    [JsonObject(Title = "warehouse")]
    public class WarehouseDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the warehouse name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        [JsonProperty("admin_comment")]
        public string AdminComment { get; set; }

        /// <summary>
        /// Gets or sets the address identifier of the warehouse
        /// </summary>
        [JsonProperty("address")]
        public AddressDto Address { get; set; }
    }
}
