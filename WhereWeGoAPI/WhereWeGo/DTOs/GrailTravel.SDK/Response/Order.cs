using System;
using System.Collections.Generic;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;

namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Response
{
    public class Order
    {
        public string id { get; set; }
        public Railway railway { get; set; }
        public From from { get; set; }
        public To to { get; set; }
        public DateTime departure { get; set; }
        public DateTime created_at { get; set; }
        public List<Passenger> passengers { get; set; }
        public List<Ticket> tickets { get; set; }
        public string PNR { get; set; }
    }
}