using System.Collections.Generic;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;

namespace WhereWeGoAPI.DTOs
{
    public class Booking
    {
        public string From_Code { get; set; }

        public string To_Code { get; set; }

        public Contact Contactor { get; set; }

        public IList<Passenger> Passengers { get; set; }
    }
}