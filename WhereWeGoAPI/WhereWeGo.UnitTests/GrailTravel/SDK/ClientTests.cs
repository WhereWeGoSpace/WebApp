using System;
using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Booking;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Search;
using WhereWeGoAPI.Models.GrailTravel.SDK;
using Passenger = WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests.Passenger;

namespace WhereWeGoAPI.UnitTests.GrailTravel.SDK
{
    internal class ClientTests
    {
        private DetieClient _client;
        private AsyncKey _asyncKeyKey;
        private String _SearchTextResult;
        private List<SearchResponse> _searchResult;
        private AsyncKey _bookingAsyncKeyKey;
        private BookingResponse bookingResult;
        private AsyncKey _confirmAsyncKey;

        [SetUp]
        public void Setup()
        {
            _client = new DetieClient();
        }

        [Ignore("_github上的測試SampleCode")]
        [Test]
        public void T1_GetSearch_github上的測試SampleCode()
        {
            var searchReqeust = new SearchRequest
            {
                StartStationCode = "ST_EZVVG1X5",
                DestinationStationCode = "ST_D8NNN9ZK",
                StartTime = DateTime.Now.AddDays(20),
                NumberOfAdult = 1,
                NumberOfChildren = 0
            };

            var dateTime = DateTime.Now.ToUniversalTime();
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, searchReqeust);
            var signature = secure.Sign();

            var client = new RestClient(Config.GrailTravelHost);

            var request = new RestRequest($"api/v2/online_solutions?{searchReqeust.GetURL()}", Method.GET);
            request.AddHeader("From", Config.ApiKey);
            request.AddHeader("Date", dateTime.ToString("r"));
            request.AddHeader("Authorization", signature);
            request.AddHeader("Api-Locale", "zh-CN");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = client.Get(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            Console.WriteLine(response.Content);
        }

        private String GetSearchResult()
        {
            var searchReqeust = new SearchRequest
            {
                StartStationCode = "ST_EZVVG1X5",
                DestinationStationCode = "ST_D8NNN9ZK",
                StartTime = DateTime.Now.AddDays(20),
                NumberOfAdult = 1,
                NumberOfChildren = 0
            };
            
            //Act
            var asyncKey = _client.Search(searchReqeust);

            return _client.Search_Async(asyncKey);
        }

        [Test]
        [Order(0)]
        public void T2_Search_進行路線查詢_應能得到AsyncKey()
        {
            var searchReqeust = new SearchRequest
            {
                StartStationCode = "ST_EZVVG1X5",
                DestinationStationCode = "ST_D8NNN9ZK",
                StartTime = DateTime.Now.AddDays(20),
                NumberOfAdult = 1,
                NumberOfChildren = 0
            };

            _asyncKeyKey = _client.Search(searchReqeust);

            _client.Response.StatusCode.Should().Be(HttpStatusCode.OK);
            Console.Write(_asyncKeyKey);
        }

        [Test]
        [Order(1)]
        public void T3_Search_先進行路線查詢_取得AsyncKey後_再查詢結果()
        {
            _SearchTextResult = _client.Search_Async(_asyncKeyKey);

            //Assert
            _client.Response.StatusCode.Should().Be(HttpStatusCode.OK);

            Console.Write(_SearchTextResult);
            Console.Write(_client.Response.Content);

            _searchResult = JsonConvert.DeserializeObject<List<SearchResponse>>(_SearchTextResult);
            _searchResult.Count.Should().BeGreaterThan(0);
            _searchResult[0].solutions.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(2)]
        public void T4_Booking_調用Book_API()
        {
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
                    _searchResult[0].solutions[0].sections[0].offers[0].services[0].booking_code
                }
            };
            _bookingAsyncKeyKey = _client.Booking(bookingRequest);

            Console.Write(_client.Response.Content);
            
            //Assert
            _client.Response.StatusCode.Should().Be(HttpStatusCode.Created);
            Console.Write(_bookingAsyncKeyKey);
        }

        [Test]
        [Order(3)]
        public void T5_Booking_取得Booking結果()
        {
            bookingResult = _client.Booking_Async(_bookingAsyncKeyKey);
            Console.Write(_client.Response.Content);
            Console.Write(bookingResult);
            _client.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        [Order(4)]
        public void T6_Confirm_調用Confirm_API()
        {
            var confirmRequest = new ConfirmRequest
            {
                credit_card = new CreditCard
                {
                    number = "37887690145*******",
                    exp_month = 11,
                    exp_year = 20,
                    cvv = "***"
                }
            };

            Console.WriteLine($"OnLine_OrderId={bookingResult.id}");

            _confirmAsyncKey = _client.Confirm(bookingResult.id, confirmRequest);
            Console.WriteLine(_client.Response.Content);
            
            _client.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        [Order(5)]
        public void T7_Confirm_取得Confirm結果_API()
        {
            var confirmResult = _client.Confirm_Async(_confirmAsyncKey);

            Console.WriteLine(confirmResult);

            _client.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}