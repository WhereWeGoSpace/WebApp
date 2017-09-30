using System;
using System.Collections.Generic;

namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Confirm
{
    public class ConfirmResponse
    {
        public string id { get; set; }
        public Order order { get; set; }
        public DateTime created_at { get; set; }
        public TicketPrice ticket_price { get; set; }
        public PaymentPrice payment_price { get; set; }
        public RtpPrice rtp_price { get; set; }
        public ChargingPrice charging_price { get; set; }
        public RebateAmount rebate_amount { get; set; }
        public List<Record> records { get; set; }
    }
}