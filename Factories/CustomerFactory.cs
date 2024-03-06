using System;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Customers;

namespace RESTfulAPI.Factories
{
    public class CustomerFactory : IFactory<Customer>
    {
        public Task<Customer> InitializeAsync()
        {
            var defaultCustomer = new Customer
                                  {
                                      CustomerGuid = Guid.NewGuid(),
                                      CreatedOnUtc = DateTime.UtcNow,
                                      LastActivityDateUtc = DateTime.UtcNow,
                                      Active = true
                                  };

            return Task.FromResult(defaultCustomer);
        }
    }
}
