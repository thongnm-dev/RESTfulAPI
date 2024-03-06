using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.Categories;

namespace RESTfulAPI.MappingExtensions
{
    public static class CategoryDtoMappings
    {
        public static CategoryDto ToDto(this Category category)
        {
            return category.MapTo<Category, CategoryDto>();
        }

        public static Category ToEntity(this CategoryDto categoryDto)
        {
            return categoryDto.MapTo<CategoryDto, Category>();
        }
    }
}
