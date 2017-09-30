using System;

namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Response
{
    public class Train
    {
        public string number { get; set; }
        public string type { get; set; }
        public From from { get; set; }
        public To to { get; set; }
        public DateTime departure { get; set; }
        public DateTime arrival { get; set; }
    }
}