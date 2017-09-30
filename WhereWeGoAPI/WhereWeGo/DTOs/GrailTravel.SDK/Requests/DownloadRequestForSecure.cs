using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WhereWeGo.DTOs.GrailTravel.SDK.Requests
{
    public class DownloadRequestForSecure :RequestBase
    {
        [JsonProperty("online_order_id")]
        public string online_order_id { get; set; }
    }
}