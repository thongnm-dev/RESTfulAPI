using System.Collections.Generic;
using RESTfulAPI.Core.Domain.Shipping;

namespace RESTfulAPI.Services;

public interface IWarehouseApiService
{
    IList<Warehouse> GetWarehouses(IList<int> ids = null, int? productId = null);

    Warehouse GetWarehouseById(int id);
}
