using System;
using Newtonsoft.Json;

namespace WhereWeGo.GrailTravel.SDK.Requests
{
    /// <summary>
    /// 搜尋車票所需要輸入的參數
    /// </summary>
    /// <seealso cref="WhereWeGo.GrailTravel.SDK.Requests.RequestBase" />
    public class SearchRequest : RequestBase
    {
        /// <summary>
        /// 起始站编码
        /// </summary>
        /// <value>
        /// The start station code.
        /// </value>
        [JsonProperty("from")]
        public string StartStationCode { get; set; }

        /// <summary>
        /// 终点站编码
        /// </summary>
        /// <value>
        /// The destination station code.
        /// </value>
        [JsonProperty("to")]
        public string DestinationStationCode { get; set; }

        /// <summary>
        /// 出发日期，格式为yyyy-MM-dd
        /// </summary>
        /// <value>
        /// The start time string.
        /// </value>
        [JsonProperty("date")]
        public string StartDateString => StartTime.ToString("yyyy-MM-dd");

        [JsonProperty("time")]
        public string StartTimeString => StartTime.ToString("HH:mm");


        /// <summary>
        /// 成年人人数
        /// </summary>
        /// <value>
        /// The number of adult.
        /// </value>
        [JsonProperty("adult")]
        public int NumberOfAdult { get; set; }

        /// <summary>
        /// 儿童人数
        /// </summary>
        /// <value>
        /// The number of children.
        /// </value>
        [JsonProperty("child")]
        public int NumberOfChildren { get; set; }


        public DateTime StartTime { get; set; }
    }
}