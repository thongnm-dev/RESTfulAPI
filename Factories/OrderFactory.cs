using System;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Orders;
using RESTfulAPI.Core.Domain.Payments;
using RESTfulAPI.Core.Domain.Shipping;

namespace RESTfulAPI.Factories
{
    public class OrderFactory : IFactory<Order>
    {
        public Task<Order> InitializeAsync()
        {
            var order = new Order();

            order.CreatedOnUtc = DateTime.UtcNow;
            order.OrderGuid = new Guid();
            order.PaymentStatus = PaymentStatus.Pending;
            order.ShippingStatus = ShippingStatus.NotYetShipped;
            order.OrderStatus = OrderStatus.Pending;

            return Task.FromResult(order);
        }
    }
}
