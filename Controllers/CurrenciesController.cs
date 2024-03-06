using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.Core.Domain.Directory;
using RESTfulAPI.Attributes;
using RESTfulAPI.DTO;
using RESTfulAPI.DTO.Errors;
using RESTfulAPI.Helpers;
using RESTfulAPI.JSON.ActionResults;
using RESTfulAPI.JSON.Serializers;
using RESTfulAPI.Services;
using RESTfulAPI.Services.Authentication;
using RESTfulAPI.Services.Customers;
using RESTfulAPI.Services.Directory;
using RESTfulAPI.Services.Discounts;
using RESTfulAPI.Services.Localization;
using RESTfulAPI.Services.Logging;
using RESTfulAPI.Services.Media;
using RESTfulAPI.Services.Security;
using RESTfulAPI.Services.Stores;

namespace RESTfulAPI.Controllers
{
	public class CurrenciesController : BaseApiController
	{
		private readonly IDTOHelper _dtoHelper;
		private readonly ICustomerApiService _customerApiService;
		private readonly IAuthenticationService _authenticationService;
		private readonly ICurrencyService _currencyService;

		public CurrenciesController(
			IJsonFieldsSerializer jsonFieldsSerializer,
			IAclService aclService,
			ICustomerService customerService,
			IStoreMappingService storeMappingService,
			IStoreService storeService,
			IDiscountService discountService,
			ICustomerActivityService customerActivityService,
			ILocalizationService localizationService,
			IPictureService pictureService,
			ICurrencyService currencyService,
			IDTOHelper dtoHelper,
			ICustomerApiService customerApiService,
			IAuthenticationService authenticationService)
			: base(jsonFieldsSerializer,
				   aclService,
				   customerService,
				   storeMappingService,
				   storeService,
				   discountService,
				   customerActivityService,
				   localizationService,
				   pictureService)
		{
			_currencyService = currencyService;
			_dtoHelper = dtoHelper;
			_customerApiService = customerApiService;
			_authenticationService = authenticationService;
		}

		/// <summary>
		///     Retrieve all currencies
		/// </summary>
		/// <param name="fields">Fields from the language you want your json to contain</param>
		[HttpGet]
		[Route("/api/currencies", Name = "GetAllCurrencies")]
		[ProducesResponseType(typeof(CurrenciesRootObject), (int)HttpStatusCode.OK)]
		[ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
		[GetRequestsErrorInterceptorActionFilter]
		public async Task<IActionResult> GetAllCurrencies([FromQuery] int? storeId = null, [FromQuery] string fields = null)
		{
			// no permissions required

			var allCurrencies = await _currencyService.GetAllCurrenciesAsync(storeId: storeId ?? 0);

			IList<CurrencyDto> currenciesAsDto = await allCurrencies.SelectAwait(async language => await _dtoHelper.PrepareCurrencyDtoAsync(language)).ToListAsync();

			var currenciesRootObject = new CurrenciesRootObject
			{
				Currencies = currenciesAsDto
			};

			var json = JsonFieldsSerializer.Serialize(currenciesRootObject, fields ?? "");

			return new RawJsonActionResult(json);
		}

		[HttpGet]
		[Route("/api/currencies/primary", Name = "GetPrimaryCurrency")]
		[ProducesResponseType(typeof(CurrencyDto), (int)HttpStatusCode.OK)]
		[ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
		[ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.Unauthorized)]
		public async Task<IActionResult> GetPrimaryCurrency([FromServices] CurrencySettings currencySettings)
		{
			var primaryStoreCurrency = await _currencyService.GetCurrencyByIdAsync(currencySettings.PrimaryStoreCurrencyId);
			if (primaryStoreCurrency is null)
				return NoContent();
			var currencyDto = await _dtoHelper.PrepareCurrencyDtoAsync(primaryStoreCurrency);
			return Ok(currencyDto);
		}

		[HttpGet]
		[Route("/api/currencies/current", Name = "GetCurrentCurrency")]
		[ProducesResponseType(typeof(CurrencyDto), (int)HttpStatusCode.OK)]
		[ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
		[ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.Unauthorized)]
		public async Task<IActionResult> GetCurrentCurrency()
		{
			var customer = await _authenticationService.GetAuthenticatedCustomerAsync();
			if (customer is null)
				return Error(HttpStatusCode.Unauthorized);
			// no permissions required
			var currency = await _customerApiService.GetCustomerCurrencyAsync(customer);
			if (currency is null)
				return NoContent();
			var currencyDto = await _dtoHelper.PrepareCurrencyDtoAsync(currency);
			return Ok(currencyDto);
		}

		[HttpPost]
		[Route("/api/currencies/current", Name = "SetCurrentCurrency")]
		[ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
		[ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.Unauthorized)]
		public async Task<IActionResult> SetCurrentCurrency([FromQuery] int id)
		{
			var customer = await _authenticationService.GetAuthenticatedCustomerAsync();
			if (customer is null)
				return Error(HttpStatusCode.Unauthorized);
			// no permissions required
			var currency = await _currencyService.GetCurrencyByIdAsync(id);
			if (currency is null)
				return NotFound();
			await _customerApiService.SetCustomerCurrencyAsync(customer, currency);
			return NoContent();
		}
	}
}
