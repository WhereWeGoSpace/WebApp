using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests
{
    public abstract class RequestBase
    {
        public Dictionary<string, string> GetSignatureSources()
        {
            var dic = new Dictionary<string, string>();
            var properties = GetType().GetProperties();
            foreach (var prop in properties.Where(it => it.PropertyType.BaseType !=null &&( it.PropertyType.BaseType.Name == "Object" || it.PropertyType.BaseType.Name == "ValueType")))
            {
                
                var attrs = prop.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    var authAttr = attr as JsonPropertyAttribute;
                    if (authAttr != null)
                    {
                        if (prop.PropertyType.Name == "Boolean")
                        {
                            dic[authAttr.PropertyName] = prop.GetValue(this).ToString().ToLower();
                        }
                        else
                        dic[authAttr.PropertyName] = prop.GetValue(this).ToString();
                    }
                }
            }

            return dic;
        }

        public string GetURL()
        {
            var dic = GetSignatureSources();
            return string.Join("&", dic.Select(x => $"{x.Key}={x.Value}"));
        }
    }
}