using System;
using System.Collections.Generic;

namespace WhereWeGo.GrailTravel.SDK.Response.Search
{
    /// <summary>
    /// 搜尋車票所回應的資料結構
    /// </summary>
    public class SearchResponse
    {
        /// <summary>
        /// 铁路公司编码，详见Railway编码表格
        /// </summary>
        /// <value>
        /// The railway.
        /// </value>
        public Railway railway { get; set; }
        /// <summary>
        /// 旅程方案列表，详见Solution信息表格
        /// </summary>
        /// <value>
        /// The solution.
        /// </value>
        public IList<Solution> solutions { get; set; }
    }

    /// <summary>
    /// Railway编码
    /// 铁路公司        | 英文名        | 值
    /// 意铁           | Trenitalia   | TI
    /// 德铁           | DbBahn       | DB
    /// 法拉利铁路      | Italo        | NTV
    /// Flixbus大巴公司 | Flixbus      | FB
    /// </summary>
    public class Railway
    {
        public string code { get; set; }
    }

    /// <summary>
    /// 起始站信息,详见Station车站信息表格
    /// </summary>
    public class From
    {
        /// <summary>
        /// 车站编码
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string code { get; set; }
        /// <summary>
        /// 车站名称
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }
    }

    /// <summary>
    /// 终点站编码，详见Station车站信息表格
    /// </summary>
    public class To
    {
        /// <summary>
        /// 车站编码
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string code { get; set; }
        /// <summary>
        /// 车站名称
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }
    }

    public class Duration
    {
        public int hour { get; set; }
        public int minutes { get; set; }
    }

    public class Available
    {
        public int seats { get; set; }
    }

    public class Price
    {
        public string currency { get; set; }
        public int cents { get; set; }
    }

    public class Service
    {
        public string code { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public Available available { get; set; }
        public Price price { get; set; }
        public string booking_code { get; set; }
    }

    public class Offer
    {
        public string code { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public IList<Service> services { get; set; }
    }

    public class Train
    {
        public string number { get; set; }
        public string type { get; set; }
        public From from { get; set; }
        public To to { get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
    }

    public class Section
    {
        public IList<Offer> offers { get; set; }
        public IList<Train> trains { get; set; }
    }

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