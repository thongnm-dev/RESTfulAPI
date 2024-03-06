using System.Collections.Generic;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.Infrastructure;

namespace RESTfulAPI.Services
{
    public interface IProductManufacturerMappingsApiService
    {
        IList<ProductManufacturer> GetMappings(
            int? productId = null, int? manufacturerId = null, int limit = Constants.Configurations.DefaultLimit,
            int page = Constants.Configurations.DefaultPageValue, int sinceId = Constants.Configurations.DefaultSinceId);

        int GetMappingsCount(int? productId = null, int? manufacturerId = null);

        Task<ProductManufacturer> GetByIdAsync(int id);
    }
}
