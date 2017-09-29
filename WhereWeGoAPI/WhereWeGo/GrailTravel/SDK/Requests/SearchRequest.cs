using System;
using Newtonsoft.Json;

namespace WhereWeGo.GrailTravel.SDK.Requests
{
    public class SearchRequest : RequestBase
    {
        [JsonProperty("s")]
        public string StartStationCode { get; set; }

        [JsonProperty("d")]
        public string DestinationStationCode { get; set; }

        [JsonProperty("dt")]
        public string StartTimeString => StartTime.ToString("yyyy-MM-dd HH:mm");

        [JsonProperty("na")]
        public int NumberOfAdult { get; set; }

        [JsonProperty("nc")]
        public int NumberOfChildren { get; set; }


        public DateTime StartTime { get; set; }
    }
}