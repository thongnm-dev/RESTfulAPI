using System;
using System.Collections.Generic;
using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.Infrastructure;

namespace RESTfulAPI.Services
{
    public interface IManufacturerApiService
    {
        Manufacturer GetManufacturerById(int manufacturerId);

        IList<Manufacturer> GetManufacturers(
            IList<int> ids = null,
            DateTime? createdAtMin = null, DateTime? createdAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null,
            int limit = Constants.Configurations.DefaultLimit, int page = Constants.Configurations.DefaultPageValue,
            int sinceId = Constants.Configurations.DefaultSinceId,
            int? productId = null, bool? publishedStatus = null, int? languageId = null);

        int GetManufacturersCount(
            DateTime? createdAtMin = null, DateTime? createdAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null,
            bool? publishedStatus = null, int? productId = null);
    }
}
