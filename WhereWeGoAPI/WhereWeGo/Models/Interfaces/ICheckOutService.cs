using WhereWeGo.DTOs.GrailTravel.SDK.Requests;

namespace WhereWeGo.Models.Interfaces
{
    public interface ICheckOutService
    {
        bool Pay(decimal amount);
        BookingRequest BookTraveling(string from_code, string to_code);
    }
}
