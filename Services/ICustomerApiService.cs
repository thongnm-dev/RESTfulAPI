using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Customers;
using RESTfulAPI.Core.Domain.Directory;
using RESTfulAPI.Core.Domain.Localization;
using RESTfulAPI.DTO.Customers;
using RESTfulAPI.Infrastructure;

namespace RESTfulAPI.Services
{
    public interface ICustomerApiService
    {
        Task<int> GetCustomersCountAsync();

        Task<CustomerDto> GetCustomerByIdAsync(int id, bool showDeleted = false);

        Task<Customer> GetCustomerEntityByIdAsync(int id);

        Task<IList<CustomerDto>> GetCustomersDtosAsync(
            DateTime? createdAtMin = null, DateTime? createdAtMax = null,
            int limit = Constants.Configurations.DefaultLimit, int page = Constants.Configurations.DefaultPageValue,
            int sinceId = Constants.Configurations.DefaultSinceId);

        Task<IList<CustomerDto>> SearchAsync(
            string query = "", string order = Constants.Configurations.DefaultOrder,
            int page = Constants.Configurations.DefaultPageValue, int limit = Constants.Configurations.DefaultLimit);

        Task<Dictionary<string, string>> GetFirstAndLastNameByCustomerIdAsync(int customerId);

        /// <summary>
        /// Gets current user working language
        /// </summary>
        Task<Language> GetCustomerLanguageAsync(Customer customer);

        /// <summary>
        /// Sets current user working language
        /// </summary>
        /// <param name="language">Language</param>
        Task SetCustomerLanguageAsync(Customer customer, Language language);

        /// <summary>
        /// Gets or sets current user working currency
        /// </summary>
        Task<Currency> GetCustomerCurrencyAsync(Customer customer);

        /// <summary>
        /// Sets current user working currency
        /// </summary>
        /// <param name="currency">Currency</param>
        Task SetCustomerCurrencyAsync(Customer customer, Currency currency);
    }
}
