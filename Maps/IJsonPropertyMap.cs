using System;
using System.Collections.Generic;

namespace RESTfulAPI.Maps
{
    public interface IJsonPropertyMapper
    {
        Dictionary<string, Tuple<string, Type>> GetMap(Type type);
    }
}
