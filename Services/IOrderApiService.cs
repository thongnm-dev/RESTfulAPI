using System;
using System.Collections.Generic;
using RESTfulAPI.Core.Domain.Orders;
using RESTfulAPI.Core.Domain.Payments;
using RESTfulAPI.Core.Domain.Shipping;
using RESTfulAPI.Infrastructure;

namespace RESTfulAPI.Services
{
    public interface IOrderApiService
    {
        IList<Order> GetOrdersByCustomerId(int customerId);

        IList<Order> GetOrders(
            IList<int> ids = null, DateTime? createdAtMin = null, DateTime? createdAtMax = null,
            int limit = Constants.Configurations.DefaultLimit, int page = Constants.Configurations.DefaultPageValue,
            int sinceId = Constants.Configurations.DefaultSinceId, OrderStatus? status = null, PaymentStatus? paymentStatus = null,
            ShippingStatus? shippingStatus = null, int? customerId = null, int? storeId = null);

        Order GetOrderById(int orderId);

        int GetOrdersCount(
            DateTime? createdAtMin = null, DateTime? createdAtMax = null, OrderStatus? status = null,
            PaymentStatus? paymentStatus = null, ShippingStatus? shippingStatus = null,
            int? customerId = null, int? storeId = null);
    }
}
