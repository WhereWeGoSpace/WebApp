using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WhereWeGo.DTOs.GrailTravel.SDK.Requests;

namespace WhereWeGo.Models.GrailTravel.SDK
{
    public class ParamSecure
    {
        public ParamSecure(string secret, string apiKey, DateTime datetime, RequestBase request)
        {
            Secret = secret;
            ApiKey = apiKey;
            CurrentTime = datetime;
            Request = request;
        }

        public string Secret { get; set; }
        public DateTime CurrentTime { get; set; }
        public RequestBase Request { get; set; }
        public string ApiKey { get; }

        public string Sign()
        {
            var sources = Request.GetSignatureSources();
            sources["api_key"] = ApiKey;
            sources["t"] = new DateTimeOffset(CurrentTime).ToUnixTimeSeconds().ToString();
            var sortedSources = new SortedDictionary<string, string>(sources);

            var input = string.Join("", sortedSources.OrderBy(x=>x.Key).Select(x => $"{x.Key}={x.Value}").ToList());

            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input + Secret));

                var sb = new StringBuilder();

                foreach (var t in data)
                    sb.Append(t.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}