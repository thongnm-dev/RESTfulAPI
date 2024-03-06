﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RESTfulAPI.Authorization.Requirements;

namespace RESTfulAPI.Authorization.Policies
{
    public class CustomerRoleAuthorizationPolicy : AuthorizationHandler<CustomerRoleRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomerRoleRequirement requirement)
        {
            if (await requirement.IsCustomerInRoleAsync())
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
