using RESTfulAPI.Core.Domain.Localization;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.Languages;

namespace RESTfulAPI.MappingExtensions
{
    public static class LanguageDtoMappings
    {
        public static LanguageDto ToDto(this Language language)
        {
            return language.MapTo<Language, LanguageDto>();
        }
    }
}
