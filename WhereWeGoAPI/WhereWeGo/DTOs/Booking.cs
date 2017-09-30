using System.Collections.Generic;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response;

namespace WhereWeGoAPI.DTOs
{
    public class Booking
    {
        public string From_Code { get; set; }

        public string To_Code { get; set; }

        public string Booking_Code { get; set; }

        public Contact Contactor { get; set; }

        public IList<Passenger> Passengers { get; set; }
    }
}