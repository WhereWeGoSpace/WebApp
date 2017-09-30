using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RestSharp;
using WhereWeGo.GrailTravel.SDK;
using WhereWeGo.GrailTravel.SDK.Requests;
using WhereWeGo.GrailTravel.SDK.Response;
using WhereWeGo.GrailTravel.SDK.Response.Search;

namespace WhereWeGo.UnitTests.GrailTravel.SDK
{
    internal class ClientTests
    {
        private DetieClient _client;

        [SetUp]
        public void Setup() 
        {
             _client = new DetieClient();
        }

        [Test(Description = "測試呼叫API, but Server 端一直回應 httpStatus 500的錯誤")]
        public void GetSearch_github上的測試SampleCode()
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

            return _client.GetSearchResult(asyncKey);
        }

        [Test]
        public void Search_進行路線查詢_應能得到AsyncKey()
        {
            var searchReqeust = new SearchRequest
            {
                StartStationCode = "ST_EZVVG1X5",
                DestinationStationCode = "ST_D8NNN9ZK",
                StartTime = DateTime.Now.AddDays(20),
                NumberOfAdult = 1,
                NumberOfChildren = 0
            };

            var actual = _client.Search(searchReqeust);

            _client.Response.StatusCode.Should().Be(HttpStatusCode.OK);
            Console.Write(actual);
        }

        [Test]
        public void GetSearchResult_先進行路線查詢_取得AsyncKey後_再查詢結果()
        {

            var actual = GetSearchResult();      

            //Assert
            _client.Response.StatusCode.Should().Be(HttpStatusCode.OK);

            Console.Write(actual);
            Console.Write(_client.Response.Content);

            var response = JsonConvert.DeserializeObject<List<SearchResponse>>(actual);
            response.Count.Should().BeGreaterThan(0);
            response[0].solutions.Count.Should().BeGreaterThan(0);
            
        }

        [Test]
        public void Booking_調用Book_API()
        {
            var bookingRequest = new BookingRequest
            {
                contact = new Contact()
                {
                    address = "beijing",
                    email = "lp@163.com",
                    name = "Liping",
                    phone = "10086",
                    postcode = "100100",
                },
                passengers = new List<Passenger>
                {
                    new Passenger()
                    {
                        last_name= "zhang",
                        first_name= "san",
                        birthdate= "1986-09-01",
                        passport= "A123456",
                        email= "x@a.cn",
                        phone= "15000367081",
                        gender= "male"
                    }
                },
                seat_reserved = true,
                sections = new List<String>()
                {
                    "P_NPB7SR"
                }
            };
            var bookingAsyncKey = _client.Booking(bookingRequest);

            Console.Write(_client.Response.Content);
            //Assert
            _client.Response.StatusCode.Should().Be(HttpStatusCode.Created);
            Console.Write(bookingAsyncKey);
        }

        [Test]
        public void Booking_取得Booking結果()
        {
            var searchResult = GetSearchResult();
            var searchRoute = JsonConvert.DeserializeObject<List<SearchResponse>>(searchResult);

            var bookingRequest = new BookingRequest
            {
                contact = new Contact()
                {
                    address = "beijing",
                    email = "lp@163.com",
                    name = "Liping",
                    phone = "10086",
                    postcode = "100100",
                },
                passengers = new List<Passenger>
                {
                    new Passenger()
                    {
                        last_name= "zhang",
                        first_name= "san",
                        birthdate= "1986-09-01",
                        passport= "A123456",
                        email= "x@a.cn",
                        phone= "15000367081",
                        gender= "male"
                    }
                },
                seat_reserved = true,
                sections = new List<String>()
                {
                    searchRoute[0].solutions[0].sections[0].offers[0].services[0].booking_code
                    //"P_NPB7SR"
                }
            };
            var bookingAsyncKey = _client.Booking(bookingRequest);

            var response = _client.Booking_Async(bookingAsyncKey);
            Console.Write(_client.Response.Content);
            Console.Write(response);
            _client.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


    }
}