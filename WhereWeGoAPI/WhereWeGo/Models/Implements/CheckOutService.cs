using System;
using System.Collections.Generic;
using Newtonsoft.Json;
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

        public BookingRequest BookTraveling(string from_code, string to_code)
        {
            var searchResult = GetSearchResult(from_code, to_code);
            var searchRoute = JsonConvert.DeserializeObject<List<SearchResponse>>(searchResult);

            var bookingRequest = new BookingRequest
            {
                contact = new Contact
                {
                    address = "beijing",
                    email = "lp@163.com",
                    name = "Liping",
                    phone = "10086",
                    postcode = "100100"
                },
                passengers = new List<Passenger>
                {
                    new Passenger
                    {
                        last_name = "zhang",
                        first_name = "san",
                        birthdate = "1986-09-01",
                        passport = "A123456",
                        email = "x@a.cn",
                        phone = "15000367081",
                        gender = "male"
                    }
                },
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