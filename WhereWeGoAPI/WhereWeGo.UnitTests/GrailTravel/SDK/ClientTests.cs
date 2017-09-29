using System;
using System.Net;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using WhereWeGo.GrailTravel.SDK;
using WhereWeGo.GrailTravel.SDK.Requests;

namespace WhereWeGo.UnitTests.GrailTravel.SDK
{
    internal class ClientTests
    {
        [Test(Description = "測試呼叫API, but Server 端一直回應 httpStatus 500的錯誤")]
        public void GetSearch()
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

            var request = new RestRequest($"/api/v2/online_solutions?{searchReqeust.GetURL()}", Method.GET);
            request.AddHeader("From", Config.ApiKey);
            request.AddHeader("Date", dateTime.ToString("r"));
            request.AddHeader("Authorization", signature);

            var response = client.Get(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            Console.WriteLine(response.Content);
        }
    }
}