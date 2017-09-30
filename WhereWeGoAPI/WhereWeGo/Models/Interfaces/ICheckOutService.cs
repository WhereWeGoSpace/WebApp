using WhereWeGo.DTOs.GrailTravel.SDK.Response.Confirm;
using WhereWeGoAPI.DTOs;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Booking;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Confirm;

namespace WhereWeGoAPI.Models.Interfaces
{
    public interface ICheckOutService
    {
        ConfirmResponse Pay(string bookingId, ConfirmRequest payInfo);
        BookingResponse BookTraveling(Booking bookingInfo);
    }
}
