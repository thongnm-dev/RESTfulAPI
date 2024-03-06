using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RESTfulAPI.Core.Configuration;
using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.Core.Domain.Common;
using RESTfulAPI.Core.Domain.Customers;
using RESTfulAPI.Core.Domain.Orders;
using RESTfulAPI.Core.Domain.Topics;
using RESTfulAPI.Core.Infrastructure;

using RESTfulAPI.Converters;
using RESTfulAPI.Factories;
using RESTfulAPI.Helpers;
using RESTfulAPI.JSON.Serializers;
using RESTfulAPI.Maps;
using RESTfulAPI.ModelBinders;
using RESTfulAPI.Services;
using RESTfulAPI.Validators;
using RESTfulAPI.Services.Topics;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using RESTfulAPI.Core.Domain.Shipping;

namespace RESTfulAPI.Infrastructure
{

    public class DependencyRegister : IRESTfulAPIStartup
    {
        public int Order => 3000;

        public void Configure(IApplicationBuilder application)
        {
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerApiService, CustomerApiService>();
            services.AddScoped<ICategoryApiService, CategoryApiService>();
            services.AddScoped<IProductApiService, ProductApiService>();
            services.AddScoped<IProductCategoryMappingsApiService, ProductCategoryMappingsApiService>();
            services.AddScoped<IProductManufacturerMappingsApiService, ProductManufacturerMappingsApiService>();
            services.AddScoped<IOrderApiService, OrderApiService>();
            services.AddScoped<IShoppingCartItemApiService, ShoppingCartItemApiService>();
            services.AddScoped<IOrderItemApiService, OrderItemApiService>();
            services.AddScoped<IProductAttributesApiService, ProductAttributesApiService>();
            services.AddScoped<IProductPictureService, ProductPictureService>();
            services.AddScoped<IProductAttributeConverter, ProductAttributeConverter>();
            services.AddScoped<ISpecificationAttributeApiService, SpecificationAttributesApiService>();
            services.AddScoped<INewsLetterSubscriptionApiService, NewsLetterSubscriptionApiService>();
            services.AddScoped<IManufacturerApiService, ManufacturerApiService>();
            services.AddScoped<IWarehouseApiService, WarehouseApiService>();
            services.AddScoped<IProductWarehouseInventoriesApiService, ProductWarehouseInventoriesApiService>();

            services.AddScoped<IMappingHelper, MappingHelper>();
            services.AddScoped<ICustomerRolesHelper, CustomerRolesHelper>();
            services.AddScoped<IJsonHelper, JsonHelper>();
            services.AddScoped<IDTOHelper, DTOHelper>();

            services.AddScoped<IJsonFieldsSerializer, JsonFieldsSerializer>();

            services.AddScoped<IFieldsValidator, FieldsValidator>();

            services.AddScoped<IObjectConverter, ObjectConverter>();
            services.AddScoped<IApiTypeConverter, ApiTypeConverter>();

            services.AddScoped<IFactory<Category>, CategoryFactory>();
            services.AddScoped<IFactory<Product>, ProductFactory>();
            services.AddScoped<IFactory<Customer>, CustomerFactory>();
            services.AddScoped<IFactory<Address>, AddressFactory>();
            services.AddScoped<IFactory<Order>, OrderFactory>();
            services.AddScoped<IFactory<ShoppingCartItem>, ShoppingCartItemFactory>();
            services.AddScoped<IFactory<Manufacturer>, ManufacturerFactory>();
            services.AddScoped<IFactory<Topic>, TopicFactory>();
            services.AddScoped<IFactory<Warehouse>, WarehouseFactory>();

            services.AddScoped<IJsonPropertyMapper, JsonPropertyMapper>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Dictionary<string, object>>(); // TODO: refactor to typed class. make Scoped?

            services.AddScoped<ITopicService, TopicService>();

            services.AddScoped<IAddressApiService, AddressApiService>();

            // replace IAuthenticationService CookieAutheticationService (used in RESTfulAPICommerce web) with BearerTokenOrCookieAuthenticationService that will combine Bearer token  (used in RESTfulAPI api plugin) and Cookies authentication
            services.Replace(ServiceDescriptor.Scoped<RESTfulAPI.Services.Authentication.IAuthenticationService, BearerTokenOrCookieAuthenticationService>());

            // replace IStoreContext WebStoreContext with similar implementation that tries to determine host using api client provided header "RESTfulAPIApiClientHost"
            services.Replace(ServiceDescriptor.Scoped<RESTfulAPI.Core.IStoreContext, WebApiStoreContext>());

            services.AddScoped(typeof(ParametersModelBinder<>));
            services.AddScoped(typeof(JsonModelBinder<>));
        }
    }
}
