using System;
using System.Collections.Generic;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;

namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Booking
{
    public class BookingResponse
    {
        public string id { get; set; }
        public Railway railway { get; set; }
        public From from { get; set; }
        public To to { get; set; }
        public DateTime departure { get; set; }
        public DateTime created_at { get; set; }
        public List<Passenger> passengers { get; set; }
        public List<Ticket> tickets { get; set; }
        public TicketPrice ticket_price { get; set; }
        public PaymentPrice payment_price { get; set; }
        public RtpPrice rtp_price { get; set; }
        public ChargingPrice charging_price { get; set; }
        public RebateAmount rebate_amount { get; set; }
        public List<object> records { get; set; }
        public object memo { get; set; }
    }
}