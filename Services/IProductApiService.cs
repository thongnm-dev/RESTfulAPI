﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.Infrastructure;

namespace RESTfulAPI.Services
{
    public interface IProductApiService
    {
        IList<Product> GetProducts(
            IList<int> ids = null,
            DateTime? createdAtMin = null, DateTime? createdAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null,
            int? limit = null, int? page = null,
            int? sinceId = null,
            int? categoryId = null, string vendorName = null, bool? publishedStatus = null, IList<string> manufacturerPartNumbers = null, bool? isDownload = null);

        Task<int> GetProductsCountAsync(
            DateTime? createdAtMin = null, DateTime? createdAtMax = null,
            DateTime? updatedAtMin = null, DateTime? updatedAtMax = null, bool? publishedStatus = null,
            string vendorName = null, int? categoryId = null, IList<string> manufacturerPartNumbers = null, bool? isDownload = null);

        Product GetProductById(int productId);

        Product GetProductByIdNoTracking(int productId);
    }
}
