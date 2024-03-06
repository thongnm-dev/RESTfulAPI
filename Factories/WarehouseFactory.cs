using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Shipping;

namespace RESTfulAPI.Factories
{
    public class WarehouseFactory : IFactory<Warehouse>
    {
        public Task<Warehouse> InitializeAsync()
        {
            var warehouse = new Warehouse();
            
            return Task.FromResult(warehouse);
        }
    }
}
