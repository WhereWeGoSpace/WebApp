using System;
using System.Collections.Generic;

namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Response
{
    public class Solution
    {
        /// <summary>
        /// 起始站信息,详见Station车站信息表格
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        public From from { get; set; }
        /// <summary>
        /// 终点站编码，详见Station车站信息表格
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        public To to { get; set; }
        /// <summary>
        /// 发车时间，UTC格式的本地时间，例如："2017-03-08T13:30:00+01:00"
        /// </summary>
        /// <value>
        /// The departure.
        /// </value>
        public DateTime departure { get; set; }
        /// <summary>
        /// Duration时长信息
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public Duration duration { get; set; }
        /// <summary>
        /// 转车次数
        /// </summary>
        /// <value>
        /// The transfer times.
        /// </value>
        public int transfer_times { get; set; }
        /// <summary>
        /// Sections，行程中的不同车型，详见Sections信息表格
        /// </summary>
        /// <value>
        /// The sections.
        /// </value>
        public IList<Section> sections { get; set; }
    }
}