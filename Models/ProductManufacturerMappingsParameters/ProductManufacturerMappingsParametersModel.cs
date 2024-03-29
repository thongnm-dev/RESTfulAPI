﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RESTfulAPI.Infrastructure;
using RESTfulAPI.ModelBinders;

namespace RESTfulAPI.Models.ProductManufacturerMappingsParameters
{
    // JsonProperty is used only for swagger
    [ModelBinder(typeof(ParametersModelBinder<ProductManufacturerMappingsParametersModel>))]
    public class ProductManufacturerMappingsParametersModel : BaseManufacturerMappingsParametersModel
    {
        public ProductManufacturerMappingsParametersModel()
        {
            SinceId = Constants.Configurations.DefaultSinceId;
            Page = Constants.Configurations.DefaultPageValue;
            Limit = Constants.Configurations.DefaultLimit;
            Fields = string.Empty;
        }

        /// <summary>
        ///     Restrict results to after the specified ID
        /// </summary>
        [JsonProperty("since_id")]
        public int SinceId { get; set; }

        /// <summary>
        ///     Page to show (default: 1)
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        ///     Amount of results (default: 50) (maximum: 250)
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        ///     comma-separated list of fields to include in the response
        /// </summary>
        [JsonProperty("fields")]
        public string Fields { get; set; }
    }
}
