using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Directory;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO;

namespace RESTfulAPI.MappingExtensions
{
	public static class CountryDtoMappings
	{
        public static CountryDto ToDto(this Country address)
        {
            return address.MapTo<Country, CountryDto>();
        }

        public static Country ToEntity(this CountryDto addressDto)
        {
            return addressDto.MapTo<CountryDto, Country>();
        }
    }
}
