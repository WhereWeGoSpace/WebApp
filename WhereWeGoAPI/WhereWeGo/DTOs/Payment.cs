using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;

namespace WhereWeGoAPI.DTOs
{
    public class Payment
    {
        public string BookingId { get; set; }

        public CreditCard CreditCard { get; set; }
    }
}