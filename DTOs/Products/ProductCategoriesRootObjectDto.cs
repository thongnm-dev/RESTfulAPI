using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RESTfulAPI.DTO;
using RESTfulAPI.DTO.Categories;

namespace RESTfulAPI.DTO.Products
{
	public class ProductCategoriesRootObjectDto : ISerializableObject
	{
		[JsonProperty("product_categories")]
		public List<ProductCategoriesDto> ProductCategories { get; set; }

		public string GetPrimaryPropertyName()
		{
			return "product_categories";
		}

		public Type GetPrimaryPropertyType()
		{
			return ProductCategories.GetType();
		}
	}

	public class ProductCategoriesDto
	{
		[JsonProperty("product_id")]
		public int ProductId { get; set; }

		[JsonProperty("categories", Required = Required.Always)]
		public List<CategoryDto> Categories { get; set; }
	}
}
