using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Directory;
using RESTfulAPI.DTO;
using RESTfulAPI.AutoMapper;

namespace RESTfulAPI.MappingExtensions
{
	public static class CurrencyDtoMappings
	{
        public static CurrencyDto ToDto(this Currency currency)
        {
            return currency.MapTo<Currency, CurrencyDto>();
        }
    }
}
