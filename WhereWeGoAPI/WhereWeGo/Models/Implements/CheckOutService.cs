using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WhereWeGo.DTOs;
using WhereWeGo.DTOs.GrailTravel.SDK.Requests;
using WhereWeGo.DTOs.GrailTravel.SDK.Response.Search;
using WhereWeGo.Models.GrailTravel.SDK;
using WhereWeGo.Models.Interfaces;

namespace WhereWeGo.Models.Implements
{
    public class CheckOutService : ICheckOutService
    {
        private readonly DetieClient _client;

        public CheckOutService()
        {
            this._client = new DetieClient();
        }

        public BookingRequest BookTraveling(Booking bookingInfo)
        {
            var searchResult = GetSearchResult(bookingInfo.From_Code, bookingInfo.To_Code);
            var searchRoute = JsonConvert.DeserializeObject<List<SearchResponse>>(searchResult);

            var bookingRequest = new BookingRequest
            {
                contact = bookingInfo.Contactor,
                passengers = bookingInfo.Passengers,
                seat_reserved = true,
                sections = new List<String>
                {
                    searchRoute[0].solutions[0].sections[0].offers[0].services[0].booking_code
                    //"P_NPB7SR"
                }
            };

            return bookingRequest;
        }

        public bool Pay(decimal amount)
        {
            return true;
        }

        private String GetSearchResult(string from_code, string to_code)
        {
            var searchReqeust = new SearchRequest
            {
                StartStationCode = from_code,
                DestinationStationCode = to_code,
                StartTime = DateTime.Now.AddDays(20),
                NumberOfAdult = 1,
                NumberOfChildren = 0
            };

            //Act
            var asyncKey = _client.Search(searchReqeust);

            return _client.Search_Async(asyncKey);
        }
    }
}