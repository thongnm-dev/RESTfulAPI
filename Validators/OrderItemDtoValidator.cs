using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using RESTfulAPI.DTO.OrderItems;
using RESTfulAPI.Helpers;

namespace RESTfulAPI.Validators
{
    public class OrderItemDtoValidator : BaseDtoValidator<OrderItemDto>
    {
        #region Constructors

        public OrderItemDtoValidator(IHttpContextAccessor httpContextAccessor, IJsonHelper jsonHelper, Dictionary<string, object> requestJsonDictionary) :
            base(httpContextAccessor, jsonHelper, requestJsonDictionary)
        {
            SetProductIdRule();
            SetQuantityRule();
        }

        #endregion

        #region Private Methods

        private void SetProductIdRule()
        {
            SetGreaterThanZeroCreateOrUpdateRule(o => o.ProductId, "invalid product_id", "product_id");
        }

        private void SetQuantityRule()
        {
            SetGreaterThanZeroCreateOrUpdateRule(o => o.Quantity, "invalid quanitty", "quantity");
        }

        #endregion
    }
}
