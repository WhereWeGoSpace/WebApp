﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WhereWeGoAPI.DTOs;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Booking;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Confirm;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Search;
using WhereWeGoAPI.Models.GrailTravel.SDK;
using WhereWeGoAPI.Models.Interfaces;

namespace WhereWeGoAPI.Models.Implements
{
    public class CheckOutService : ICheckOutService
    {
        private readonly IDetieClient _client;

        public CheckOutService()
        {
            _client = new DetieClient();
        }

        public CheckOutService(IDetieClient client)
        {
            this._client = client;
        }

        public BookingResponse BookTraveling(Booking bookingInfo)
        {
            BookingResponse resp = null;

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
                }
            };

            var asycKey = _client.Booking(bookingRequest);

            resp = _client.Booking_Async(asycKey);

            return resp;
        }

        public ConfirmResponse Pay(string bookingId, ConfirmRequest payInfo)
        {
            var asyncKey = _client.Confirm(bookingId, payInfo);
            var confirmResult = _client.Confirm_Async(asyncKey);

            return confirmResult;
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