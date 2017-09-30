using System.Collections.Generic;

namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Response
{
    public class Offer
    {
        public string code { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public IList<Service> services { get; set; }
    }
}