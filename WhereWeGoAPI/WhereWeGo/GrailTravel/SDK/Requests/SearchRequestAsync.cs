using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WhereWeGo.GrailTravel.SDK.Requests
{
    public class SearchRequestAsync : RequestBase
    {
        [JsonProperty("async_key")]
        public string AsyncKey { get; set; }
    }
}