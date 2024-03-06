using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.ModelBinders;

namespace RESTfulAPI.Models.SpecificationAttributesParameters
{
    // JsonProperty is used only for swagger
    [ModelBinder(typeof(ParametersModelBinder<SpecificationAttributesCountParametersModel>))]
    public class SpecificationAttributesCountParametersModel
    {
    }
}
