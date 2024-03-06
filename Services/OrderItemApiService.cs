using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Orders;
using RESTfulAPI.DataStructures;
using RESTfulAPI.Services.Orders;

namespace RESTfulAPI.Services
{
    public class OrderItemApiService : IOrderItemApiService
    {
        private readonly IOrderService _orderService;

        public OrderItemApiService(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IList<OrderItem>> GetOrderItemsForOrderAsync(Order order, int limit, int page, int sinceId)
        {
            var orderItems = (await _orderService.GetOrderItemsAsync(order.Id)).AsQueryable();

            return new ApiList<OrderItem>(orderItems, page - 1, limit);
        }

        public async Task<int> GetOrderItemsCountAsync(Order order)
        {
            var orderItemsCount = (await _orderService.GetOrderItemsAsync(order.Id)).Count;

            return orderItemsCount;
        }

    }
}
