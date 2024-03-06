using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.Core.Domain.Directory;
using RESTfulAPI.Core.Domain.Localization;
using RESTfulAPI.Core.Domain.Orders;
using RESTfulAPI.Core.Domain.Shipping;
using RESTfulAPI.Core.Domain.Stores;
using RESTfulAPI.Core.Domain.Tax;
using RESTfulAPI.Core.Domain.Topics;
using RESTfulAPI.DTO;
using RESTfulAPI.DTO.Categories;
using RESTfulAPI.DTO.Languages;
using RESTfulAPI.DTO.Manufacturers;
using RESTfulAPI.DTO.OrderItems;
using RESTfulAPI.DTO.Orders;
using RESTfulAPI.DTO.ProductAttributes;
using RESTfulAPI.DTO.Products;
using RESTfulAPI.DTO.ShoppingCarts;
using RESTfulAPI.DTO.SpecificationAttributes;
using RESTfulAPI.DTO.Stores;
using RESTfulAPI.DTO.Warehouses;
using RESTfulAPI.DTOs.Taxes;
using RESTfulAPI.DTOs.Topics;

namespace RESTfulAPI.Helpers
{
    public interface IDTOHelper
    {
        Task<ProductDto> PrepareProductDTOAsync(Product product);
        Task<CategoryDto> PrepareCategoryDTOAsync(Category category);
        Task<OrderDto> PrepareOrderDTOAsync(Order order);
        Task<ShoppingCartItemDto> PrepareShoppingCartItemDTOAsync(ShoppingCartItem shoppingCartItem);
        Task<OrderItemDto> PrepareOrderItemDTOAsync(OrderItem orderItem);
        Task<StoreDto> PrepareStoreDTOAsync(Store store);
        Task<LanguageDto> PrepareLanguageDtoAsync(Language language);
        Task<CurrencyDto> PrepareCurrencyDtoAsync(Currency currency);
        ProductAttributeDto PrepareProductAttributeDTO(ProductAttribute productAttribute);
        ProductSpecificationAttributeDto PrepareProductSpecificationAttributeDto(ProductSpecificationAttribute productSpecificationAttribute);
        SpecificationAttributeDto PrepareSpecificationAttributeDto(SpecificationAttribute specificationAttribute);
        Task<ManufacturerDto> PrepareManufacturerDtoAsync(Manufacturer manufacturer);

        Task<WarehouseDto> PrepareWarehouseDtoAsync(Warehouse warehouse);
        TopicDto PrepareTopicDTO(Topic topic);
        TaxCategoryDto prepareTaxCategoryDto(TaxCategory taxCategory);
    }
}
