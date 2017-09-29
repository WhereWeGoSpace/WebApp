using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WhereWeGo.GrailTravel.SDK.Requests
{
    public abstract class RequestBase
    {
        public Dictionary<string, string> GetSignatureSources()
        {
            var dic = new Dictionary<string, string>();
            var properties = GetType().GetProperties();
            foreach (var prop in properties)
            {
                var attrs = prop.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    var authAttr = attr as JsonPropertyAttribute;
                    if (authAttr != null)
                        dic[authAttr.PropertyName] = prop.GetValue(this).ToString();
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