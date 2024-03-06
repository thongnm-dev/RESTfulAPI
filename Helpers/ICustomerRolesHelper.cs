using System.Collections.Generic;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Customers;

namespace RESTfulAPI.Helpers
{
    public interface ICustomerRolesHelper
    {
        Task<IList<CustomerRole>> GetValidCustomerRolesAsync(List<int> roleIds);
        bool IsInGuestsRole(IList<CustomerRole> customerRoles);
        bool IsInRegisteredRole(IList<CustomerRole> customerRoles);
    }
}
