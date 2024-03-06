using Newtonsoft.Json;
using RESTfulAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfulAPI.DTOs.Taxes
{
    public class TaxCategoriesRootObject : ISerializableObject
    {
        public TaxCategoriesRootObject()
        {
            Taxes = new List<TaxCategoryDto>();
        }

        [JsonProperty("tax_categories")]
        public IList<TaxCategoryDto> Taxes { get; set; }

        public string GetPrimaryPropertyName()
        {
            return "tax_categories";
        }

        public Type GetPrimaryPropertyType()
        {
            return typeof(TaxCategoryDto);
        }

    }

}
