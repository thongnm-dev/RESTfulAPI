using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.ModelBinders;

namespace RESTfulAPI.Models.CategoriesParameters
{
    [ModelBinder(typeof(ParametersModelBinder<CategoriesCountParametersModel>))]
    public class CategoriesCountParametersModel : BaseCategoriesParametersModel
    {
        // Nothing special here, created just for clarity.
    }
}
