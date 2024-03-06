using System;
using System.Collections.Generic;
using RESTfulAPI.Core.Domain.Messages;
using RESTfulAPI.Infrastructure;

namespace RESTfulAPI.Services
{
    public interface INewsLetterSubscriptionApiService
    {
        List<NewsLetterSubscription> GetNewsLetterSubscriptions(
            DateTime? createdAtMin = null, DateTime? createdAtMax = null,
            int limit = Constants.Configurations.DefaultLimit, int page = Constants.Configurations.DefaultPageValue,
            int sinceId = Constants.Configurations.DefaultSinceId,
            bool? onlyActive = true);
    }
}
