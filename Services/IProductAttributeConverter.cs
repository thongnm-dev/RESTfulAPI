using System.Collections.Generic;
using System.Threading.Tasks;
using RESTfulAPI.DTO;

namespace RESTfulAPI.Services
{
    public interface IProductAttributeConverter
    {
        List<ProductItemAttributeDto> Parse(string attributesXml);
        Task<string> ConvertToXmlAsync(List<ProductItemAttributeDto> attributeDtos, int productId);
    }
}
