namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Response
{
    public class Railway
    {
        /// <summary>
        /// Railway编码
        /// 铁路公司        | 英文名        | 值
        /// 意铁           | Trenitalia   | TI
        /// 德铁           | DbBahn       | DB
        /// 法拉利铁路      | Italo        | NTV
        /// Flixbus大巴公司 | Flixbus      | FB
        /// </summary>
        public string code { get; set; }
    }
}