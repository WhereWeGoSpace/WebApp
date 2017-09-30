using WhereWeGo.DTOs;
using WhereWeGo.DTOs.GrailTravel.SDK.Requests;

namespace WhereWeGo.Models.Interfaces
{
    public interface ICheckOutService
    {
        bool Pay(decimal amount);
        BookingRequest BookTraveling(Booking bookingInfo);
    }
}
