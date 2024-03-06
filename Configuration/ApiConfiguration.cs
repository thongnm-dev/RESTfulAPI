using RESTfulAPI.Core.Configuration;

namespace RESTfulAPI.Configuration
{
    public class ApiConfiguration : IConfig
    {
        public int AllowedClockSkewInMinutes { get; set; } = 5;

        public string SecurityKey { get; set; } = "NowIsTheTimeForAllGoodMenToComeToTheAideOfTheirCountry";
    }
}
