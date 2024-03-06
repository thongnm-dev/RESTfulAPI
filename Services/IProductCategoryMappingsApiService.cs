using System.Collections.Generic;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.Infrastructure;

namespace RESTfulAPI.Services
{
    public interface IProductCategoryMappingsApiService
    {
        IList<ProductCategory> GetMappings(
            int? productId = null, int? categoryId = null, int limit = Constants.Configurations.DefaultLimit,
            int page = Constants.Configurations.DefaultPageValue, int sinceId = Constants.Configurations.DefaultSinceId);

        int GetMappingsCount(int? productId = null, int? categoryId = null);

        Task<ProductCategory> GetByIdAsync(int id);
    }
}
