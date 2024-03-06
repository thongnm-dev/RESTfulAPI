using System.Collections.Generic;

namespace RESTfulAPI.Converters
{
    public interface IObjectConverter
    {
        T ToObject<T>(ICollection<KeyValuePair<string, string>> source)
            where T : class, new();
    }
}
