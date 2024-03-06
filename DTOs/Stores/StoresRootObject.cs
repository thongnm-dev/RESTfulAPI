using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RESTfulAPI.DTO.Stores
{
    public class StoresRootObject : ISerializableObject
    {
        public StoresRootObject()
        {
            Stores = new List<StoreDto>();
        }

        [JsonProperty("stores")]
        public IList<StoreDto> Stores { get; set; }

        public string GetPrimaryPropertyName()
        {
            return "stores";
        }

        public Type GetPrimaryPropertyType()
        {
            return typeof(StoreDto);
        }
    }
}
