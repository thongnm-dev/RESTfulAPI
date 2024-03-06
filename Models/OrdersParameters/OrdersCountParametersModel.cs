using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.ModelBinders;

namespace RESTfulAPI.Models.OrdersParameters
{
    [ModelBinder(typeof(ParametersModelBinder<OrdersCountParametersModel>))]
    public class OrdersCountParametersModel : BaseOrdersParametersModel
    {
        // Nothing special here, created just for clarity.
    }
}
