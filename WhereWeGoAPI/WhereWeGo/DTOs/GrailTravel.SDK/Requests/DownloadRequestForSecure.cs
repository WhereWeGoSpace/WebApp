using Newtonsoft.Json;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;

namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests
{
    public class DownloadRequestForSecure : RequestBase
    {
        [JsonProperty("online_order_id")]
        public string online_order_id { get; set; }
    }
}