using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.ModelBinders;

namespace RESTfulAPI.Models.ManufacturersParameters
{
    [ModelBinder(typeof(ParametersModelBinder<ManufacturersCountParametersModel>))]
    public class ManufacturersCountParametersModel : BaseManufacturersParametersModel
    {
        // Nothing special here, created just for clarity.
    }
}
