using System.Collections.Generic;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Orders;

namespace RESTfulAPI.Services
{
    public interface IOrderItemApiService
    {
        Task<IList<OrderItem>> GetOrderItemsForOrderAsync(Order order, int limit, int page, int sinceId);
        Task<int> GetOrderItemsCountAsync(Order order);
    }
}
