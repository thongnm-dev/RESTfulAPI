using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.ModelBinders;

namespace RESTfulAPI.Models.ProductCategoryMappingsParameters
{
    [ModelBinder(typeof(ParametersModelBinder<ProductCategoryMappingsCountParametersModel>))]
    public class ProductCategoryMappingsCountParametersModel : BaseCategoryMappingsParametersModel
    {
        // Nothing special here, created just for clarity.
    }
}
