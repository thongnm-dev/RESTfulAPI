using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.Core.Domain.Common;
using RESTfulAPI.Core.Domain.Customers;
using RESTfulAPI.Core.Domain.Directory;
using RESTfulAPI.Core.Domain.Localization;
using RESTfulAPI.Core.Domain.Messages;
using RESTfulAPI.Core.Domain.Orders;
using RESTfulAPI.Core.Domain.Shipping;
using RESTfulAPI.Core.Domain.Stores;
using RESTfulAPI.Core.Domain.Tax;
using RESTfulAPI.Core.Domain.Topics;
using RESTfulAPI.Core.Infrastructure.Mapper;
using RESTfulAPI.Areas.Admin.Models;
using RESTfulAPI.Domain;
using RESTfulAPI.DTO;
using RESTfulAPI.DTO.Categories;
using RESTfulAPI.DTO.CustomerRoles;
using RESTfulAPI.DTO.Customers;
using RESTfulAPI.DTO.Languages;
using RESTfulAPI.DTO.Manufacturers;
using RESTfulAPI.DTO.NewsLetterSubscriptions;
using RESTfulAPI.DTO.OrderItems;
using RESTfulAPI.DTO.Orders;
using RESTfulAPI.DTO.ProductAttributes;
using RESTfulAPI.DTO.ProductCategoryMappings;
using RESTfulAPI.DTO.ProductManufacturerMappings;
using RESTfulAPI.DTO.Products;
using RESTfulAPI.DTO.ProductWarehouseIventories;
using RESTfulAPI.DTO.ShoppingCarts;
using RESTfulAPI.DTO.SpecificationAttributes;
using RESTfulAPI.DTO.Stores;
using RESTfulAPI.DTO.Warehouses;
using RESTfulAPI.DTOs.StateProvinces;
using RESTfulAPI.DTOs.Taxes;
using RESTfulAPI.DTOs.Topics;
using RESTfulAPI.MappingExtensions;

namespace RESTfulAPI.AutoMapper
{
    public class ApiMapperConfiguration : Profile, IOrderedMapperProfile
    {
        public ApiMapperConfiguration()
        {
            CreateMap<ApiSettings, ConfigurationModel>();
            CreateMap<ConfigurationModel, ApiSettings>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Store, StoreDto>();

            CreateMap<ProductCategory, ProductCategoryMappingDto>();

            CreateMap<ProductManufacturer, ProductManufacturerMappingsDto>();
            CreateMap<ProductWarehouseInventory, ProductWarehouseInventoryDto>();

            CreateMap<Warehouse, WarehouseDto>();
            CreateMap<WarehouseDto, Warehouse>();

            CreateMap<Language, LanguageDto>();

            CreateMap<CustomerRole, CustomerRoleDto>();

            CreateMap<Manufacturer, ManufacturerDto>();

            CreateClientToClientApiModelMap();

            CreateAddressMap();
            CreateAddressDtoToEntityMap();
            CreateShoppingCartItemMap();

            CreateCustomerToDTOMap();

            CreateMap<OrderItem, OrderItemDto>();
            CreateOrderEntityToOrderDtoMap();

            CreateProductMap();

            CreateMap<ProductAttributeValue, ProductAttributeValueDto>();

            CreateMap<ProductAttribute, ProductAttributeDto>();

            CreateMap<ProductSpecificationAttribute, ProductSpecificationAttributeDto>();
            CreateMap<ProductAttributeCombination, ProductAttributeCombinationDto>();

            CreateMap<SpecificationAttribute, SpecificationAttributeDto>();
            CreateMap<SpecificationAttributeOption, SpecificationAttributeOptionDto>();

            CreateMap<NewsLetterSubscriptionDto, NewsLetterSubscription>();
            CreateMap<NewsLetterSubscription, NewsLetterSubscriptionDto>();

            CreateMap<Topic, TopicDto>();

            CreateMap<StateProvince, StateProvinceDto>();

            CreateMap<Country, CountryDto>();

            CreateMap<Currency, CurrencyDto>();

            CreateMap<TaxCategory, TaxCategoryDto>();
        }

        public int Order => 0;

        private new static void CreateMap<TSource, TDestination>()
        {
            AutoMapperApiConfiguration.MapperConfigurationExpression.CreateMap<TSource, TDestination>()
                                      .IgnoreAllNonExisting();
        }

        private static void CreateClientToClientApiModelMap()
        {
            //AutoMapperApiConfiguration.MapperConfigurationExpression.CreateMap<Client, ClientApiModel>()
            //    .ForMember(x => x.ClientSecret, y => y.MapFrom(src => src.ClientSecrets.FirstOrDefault().Description))
            //    .ForMember(x => x.RedirectUrl, y => y.MapFrom(src => src.RedirectUris.FirstOrDefault().RedirectUri))
            //    .ForMember(x => x.AccessTokenLifetime, y => y.MapFrom(src => src.AccessTokenLifetime))
            //    .ForMember(x => x.RefreshTokenLifetime, y => y.MapFrom(src => src.AbsoluteRefreshTokenLifetime));
        }

        private void CreateOrderEntityToOrderDtoMap()
        {
            AutoMapperApiConfiguration.MapperConfigurationExpression.CreateMap<Order, OrderDto>()
                                      .IgnoreAllNonExisting()
                                      .ForMember(x => x.Id, y => y.MapFrom(src => src.Id));
            //.ForMember(x => x.OrderItems, y => y.MapFrom(src => src.OrderItems.Select(x => x.ToDto())));
        }

        private void CreateAddressMap()
        {
            AutoMapperApiConfiguration.MapperConfigurationExpression.CreateMap<Address, AddressDto>()
                                      .IgnoreAllNonExisting()
                                      .ForMember(x => x.Id, y => y.MapFrom(src => src.Id));
            //.ForMember(x => x.CountryName,
            //           y => y.MapFrom(src => src.Country.GetWithDefault(x => x, new Country()).Name))
            //.ForMember(x => x.StateProvinceName,
            //           y => y.MapFrom(src => src.StateProvince.GetWithDefault(x => x, new StateProvince()).Name));
        }

        private void CreateAddressDtoToEntityMap()
        {
            AutoMapperApiConfiguration.MapperConfigurationExpression.CreateMap<AddressDto, Address>()
                                      .IgnoreAllNonExisting()
                                      .ForMember(x => x.Id, y => y.MapFrom(src => src.Id));
        }

        private void CreateCustomerToDTOMap()
        {
            AutoMapperApiConfiguration.MapperConfigurationExpression.CreateMap<Customer, CustomerDto>()
                                      .IgnoreAllNonExisting()
                                      .ForMember(x => x.Id, y => y.MapFrom(src => src.Id));
            //.ForMember(x => x.BillingAddress,
            //           y => y.MapFrom(src => src.BillingAddress.GetWithDefault(x => x, new Address()).ToDto()))
            //.ForMember(x => x.ShippingAddress,
            //           y => y.MapFrom(src => src.ShippingAddress.GetWithDefault(x => x, new Address()).ToDto()))
            //.ForMember(x => x.Addresses,
            //           y =>
            //               y.MapFrom(
            //                         src =>
            //                             src.Addresses.GetWithDefault(x => x, new List<Address>())
            //                                .Select(address => address.ToDto())))
            //.ForMember(x => x.ShoppingCartItems,
            //           y =>
            //               y.MapFrom(
            //                         src =>
            //                             src.ShoppingCartItems.GetWithDefault(x => x, new List<ShoppingCartItem>())
            //                                .Select(item => item.ToDto())))
            //.ForMember(x => x.RoleIds, y => y.MapFrom(src => src.CustomerRoles.Select(z => z.Id)));
        }

        private void CreateShoppingCartItemMap()
        {
            AutoMapperApiConfiguration.MapperConfigurationExpression.CreateMap<ShoppingCartItem, ShoppingCartItemDto>()
                                      .IgnoreAllNonExisting();
            //.ForMember(x => x.CustomerDto,
            //           y => y.MapFrom(src =>
            //                              src.Customer.GetWithDefault(x => x, new Customer()).ToCustomerForShoppingCartItemDto()))
            //.ForMember(x => x.ProductDto,
            //           y => y.MapFrom(src => src.Product.GetWithDefault(x => x, new Product()).ToDto()));
        }

        private void CreateProductMap()
        {
            AutoMapperApiConfiguration.MapperConfigurationExpression.CreateMap<Product, ProductDto>()
                                      .IgnoreAllNonExisting()
                                      .ForMember(p => p.RequiredProductIds, o => o.Ignore());
            //.ForMember(x => x.FullDescription, y => y.MapFrom(src => WebUtility.HtmlEncode(src.FullDescription)))
            //.ForMember(x => x.Tags,
            //           y => y.MapFrom(src => src.ProductProductTagMappings.Select(x => x.ProductTag.Name)));
        }
    }
}
