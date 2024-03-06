﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using RESTfulAPI.Core.Caching;
using RESTfulAPI.Core.Infrastructure;
using RESTfulAPI.Attributes;
using RESTfulAPI.Infrastructure;
using RESTfulAPI.Services.Caching;

namespace RESTfulAPI.Maps
{
    public class JsonPropertyMapper : IJsonPropertyMapper
    {
        public Dictionary<string, Tuple<string, Type>> GetMap(Type type)
        {
            // TODO: add caching
            return Build(type);
        }

        private Dictionary<string, Tuple<string, Type>> Build(Type type)
        {
            var mapForCurrentType = new Dictionary<string, Tuple<string, Type>>();

            var typeProps = type.GetProperties();

            foreach (var property in typeProps)
            {
                var jsonAttribute = property.GetCustomAttribute(typeof(JsonPropertyAttribute)) as JsonPropertyAttribute;
                var doNotMapAttribute = property.GetCustomAttribute(typeof(DoNotMapAttribute)) as DoNotMapAttribute;

                // If it has json attribute set and is not marked as doNotMap
                if (jsonAttribute != null && doNotMapAttribute == null)
                {
                    if (!mapForCurrentType.ContainsKey(jsonAttribute.PropertyName))
                    {
                        var value = new Tuple<string, Type>(property.Name, property.PropertyType);
                        mapForCurrentType.Add(jsonAttribute.PropertyName, value);
                    }
                }
            }

            return mapForCurrentType;
        }
    }
}
