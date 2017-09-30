using System;
using System.Collections.Generic;

namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Search
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
}