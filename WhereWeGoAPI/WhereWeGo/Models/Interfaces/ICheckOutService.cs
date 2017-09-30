using WhereWeGoAPI.DTOs;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Booking;

namespace WhereWeGoAPI.Models.Interfaces
{
    public interface ICheckOutService
    {
        string Pay(string bookingId, ConfirmRequest payInfo);
        BookingResponse BookTraveling(Booking bookingInfo);
    }
}
