using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.ModelBinders;

namespace RESTfulAPI.Models.ProductManufacturerMappingsParameters
{
    [ModelBinder(typeof(ParametersModelBinder<ProductManufacturerMappingsCountParametersModel>))]
    public class ProductManufacturerMappingsCountParametersModel : BaseManufacturerMappingsParametersModel
    {
        // Nothing special here, created just for clarity.
    }
}
