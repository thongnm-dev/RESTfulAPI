﻿using System.Collections.Generic;
using System.Linq;
using RESTfulAPI.Data;
using RESTfulAPI.Core.Domain.Catalog;
using RESTfulAPI.DataStructures;
using RESTfulAPI.Infrastructure;

namespace RESTfulAPI.Services
{
    public class SpecificationAttributesApiService : ISpecificationAttributeApiService
    {
        private readonly IRepository<ProductSpecificationAttribute> _productSpecificationAttributesRepository;
        private readonly IRepository<SpecificationAttribute> _specificationAttributesRepository;

        public SpecificationAttributesApiService(
            IRepository<ProductSpecificationAttribute> productSpecificationAttributesRepository,
            IRepository<SpecificationAttribute> specificationAttributesRepository)
        {
            _productSpecificationAttributesRepository = productSpecificationAttributesRepository;
            _specificationAttributesRepository = specificationAttributesRepository;
        }

        public IList<ProductSpecificationAttribute> GetProductSpecificationAttributes(
            int? productId = null, int? specificationAttributeOptionId = null, bool? allowFiltering = null, bool? showOnProductPage = null,
            int limit = Constants.Configurations.DefaultLimit, int page = Constants.Configurations.DefaultPageValue,
            int sinceId = Constants.Configurations.DefaultSinceId)
        {
            var query = _productSpecificationAttributesRepository.Table;

            if (productId > 0)
            {
                query = query.Where(psa => psa.ProductId == productId);
            }

            if (specificationAttributeOptionId > 0)
            {
                query = query.Where(psa => psa.SpecificationAttributeOptionId == specificationAttributeOptionId);
            }

            if (allowFiltering.HasValue)
            {
                query = query.Where(psa => psa.AllowFiltering == allowFiltering.Value);
            }

            if (showOnProductPage.HasValue)
            {
                query = query.Where(psa => psa.ShowOnProductPage == showOnProductPage.Value);
            }

            if (sinceId > 0)
            {
                query = query.Where(productAttribute => productAttribute.Id > sinceId);
            }

            query = query.OrderBy(x => x.Id);

            return new ApiList<ProductSpecificationAttribute>(query, page - 1, limit);
        }

        public IList<SpecificationAttribute> GetSpecificationAttributes(
            int limit = Constants.Configurations.DefaultLimit, int page = Constants.Configurations.DefaultPageValue,
            int sinceId = Constants.Configurations.DefaultSinceId)
        {
            var query = _specificationAttributesRepository.Table;

            if (sinceId > 0)
            {
                query = query.Where(x => x.Id > sinceId);
            }

            query = query.OrderBy(x => x.Id);

            return new ApiList<SpecificationAttribute>(query, page - 1, limit);
        }
    }
}
