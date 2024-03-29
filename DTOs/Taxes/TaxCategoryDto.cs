﻿using Newtonsoft.Json;
using RESTfulAPI.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfulAPI.DTOs.Taxes
{
    [JsonObject(Title = "taxCategory")]
    public class TaxCategoryDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        /// 
        [JsonProperty("display_order")]
        public int DisplayOrder { get; set; }
    }
}
