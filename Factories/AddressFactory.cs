using System;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Common;

namespace RESTfulAPI.Factories
{
    public class AddressFactory : IFactory<Address>
    {
        public Task<Address> InitializeAsync()
        {
            var address = new Address
                          {
                              CreatedOnUtc = DateTime.UtcNow
                          };

            return Task.FromResult(address);
        }
    }
}
