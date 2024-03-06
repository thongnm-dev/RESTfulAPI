using System.Collections.Generic;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.Infrastructure;

namespace RESTfulAPI.Services;

public interface IProductWarehouseInventoriesApiService
{
    IList<ProductWarehouseInventory> GetMappings(
        int? productId = null,
        int? categoryId = null, int limit = Constants.Configurations.DefaultLimit,
        int page = Constants.Configurations.DefaultPageValue, int sinceId = Constants.Configurations.DefaultSinceId);

    int GetIvnentoriesCount(int? productId = null, int? warehouseId = null);

    Task<ProductWarehouseInventory> GetByIdAsync(int id);
}
