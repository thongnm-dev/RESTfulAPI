using RESTfulAPI.Areas.Admin.Models;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.Domain;

namespace RESTfulAPI.MappingExtensions
{
    public static class ConfigurationMappings
    {
        public static ConfigurationModel ToModel(this ApiSettings apiSettings)
        {
            return apiSettings.MapTo<ApiSettings, ConfigurationModel>();
        }

        public static ApiSettings ToEntity(this ConfigurationModel apiSettingsModel)
        {
            return apiSettingsModel.MapTo<ConfigurationModel, ApiSettings>();
        }
    }
}
