using RestSharp;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Booking;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Confirm;

namespace WhereWeGoAPI.Models.GrailTravel.SDK
{
    public interface IDetieClient
    {
        IRestRequest Request { get; set; }
        IRestResponse Response { get; set; }

        AsyncKey Booking(BookingRequest bookingRequest);
        BookingResponse Booking_Async(AsyncKey bookingAsyncKeyKey);
        AsyncKey Confirm(string onLineOrderId, ConfirmRequest confirmRequest);
        ConfirmResponse Confirm_Async(AsyncKey confirmAsyncKeyKey);
        string Download(string onLineOrderId);
        AsyncKey Search(SearchRequest searchReqeust);
        string Search_Async(AsyncKey asyncKey);
    }
}