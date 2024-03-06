using System;
using System.Linq;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.Services.Catalog;

namespace RESTfulAPI.Factories
{
    public class CategoryFactory : IFactory<Category>
    {
        private readonly CatalogSettings _catalogSettings;
        private readonly ICategoryTemplateService _categoryTemplateService;

        public CategoryFactory(ICategoryTemplateService categoryTemplateService, CatalogSettings catalogSettings)
        {
            _categoryTemplateService = categoryTemplateService;
            _catalogSettings = catalogSettings;
        }

        public async Task<Category> InitializeAsync()
        {
            // TODO: cache the default entity.
            var defaultCategory = new Category();

            // Set the first template as the default one.
            var firstTemplate = (await _categoryTemplateService.GetAllCategoryTemplatesAsync()).FirstOrDefault();

            if (firstTemplate != null)
            {
                defaultCategory.CategoryTemplateId = firstTemplate.Id;
            }

            //default values
            defaultCategory.PageSize = _catalogSettings.DefaultCategoryPageSize;
            defaultCategory.PageSizeOptions = _catalogSettings.DefaultCategoryPageSizeOptions;
            defaultCategory.Published = true;
            defaultCategory.IncludeInTopMenu = true;
            defaultCategory.AllowCustomersToSelectPageSize = true;

            defaultCategory.CreatedOnUtc = DateTime.UtcNow;
            defaultCategory.UpdatedOnUtc = DateTime.UtcNow;

            return defaultCategory;
        }
    }
}
