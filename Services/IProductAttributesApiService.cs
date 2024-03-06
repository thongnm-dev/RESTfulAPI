using System.Collections.Generic;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.Infrastructure;

namespace RESTfulAPI.Services
{
    public interface IProductAttributesApiService
    {
        IList<ProductAttribute> GetProductAttributes(
            int limit = Constants.Configurations.DefaultLimit,
            int page = Constants.Configurations.DefaultPageValue, int sinceId = Constants.Configurations.DefaultSinceId);

        int GetProductAttributesCount();

        Task<ProductAttribute> GetByIdAsync(int id);
    }
}
