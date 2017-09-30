using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using RestSharp;
using WhereWeGo.GrailTravel.SDK.Requests;
using WhereWeGo.GrailTravel.SDK.Response;
using WhereWeGo.GrailTravel.SDK.Response.Booking;
using WhereWeGo.GrailTravel.SDK.Response.Search;

namespace WhereWeGo.GrailTravel.SDK
{
    public class DetieClient
    {
        private readonly IRestClient _client;

        public IRestRequest Request { get; set; }

        public IRestResponse Response { get; set; }

        public DetieClient()
        {
            _client = new RestClient(Config.GrailTravelHost);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public SearchAsync Search(SearchRequest searchReqeust)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, searchReqeust);
            var signature = secure.Sign();

            Request = new RestRequest($"api/v2/online_solutions?{searchReqeust.GetURL()}", Method.GET);
            Request.AddHeader("From", Config.ApiKey);
            Request.AddHeader("Date", dateTime.ToString("r"));
            Request.AddHeader("Authorization", signature);
            Request.AddHeader("Api-Locale", "zh-CN");
            
            var response = _client.Execute<SearchAsync>(Request);
            Response = response;
            return  response.Data;
        }

        public string GetSearchResult(SearchAsync async)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var request = new SearchRequestAsync() {AsyncKey = async.Async};
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, request);
            var signature = secure.Sign();

            Request = new RestRequest($"api/v2/async_results/{async.Async}", Method.GET);
            Request.AddHeader("From", Config.ApiKey);
            Request.AddHeader("Date", dateTime.ToString("r"));
            Request.AddHeader("Authorization", signature);
            Request.AddHeader("Api-Locale", "zh-CN");

            var response = _client.Execute<List<SearchResponse>>(Request);
            var count = 0;

            //資料若未Ready, 就Sleep再重試
            while (response.Content.Equals("{\"description\":\"Async result not ready.\"}") && count < 10)
            {
                Thread.Sleep(3000);
                response = _client.Execute<List<SearchResponse>>(Request);
                count++;
            }
            Response = response;
            return response.Content;
        }


        public SearchAsync Booking(BookingRequest bookingRequest)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, bookingRequest);
            var signature = secure.Sign();

            Request = new RestRequest($"api/v2/online_orders", Method.POST) {RequestFormat = DataFormat.Json};
            Request.AddBody(bookingRequest);
            Request.AddHeader("Content-Type", "application/json");
            Request.AddHeader("From", Config.ApiKey);
            Request.AddHeader("Date", dateTime.ToString("r"));
            Request.AddHeader("Authorization", signature);
            Request.AddHeader("Api-Locale", "zh-CN");

            var response = _client.Execute<SearchAsync>(Request);
            Response = response;
            return response.Data;
        }

        public BookingResponse Booking_Async(SearchAsync bookingAsyncKey)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var request = new SearchRequestAsync() { AsyncKey = bookingAsyncKey.Async };
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, request);
            var signature = secure.Sign();

            Request = new RestRequest($"api/v2/async_results/{bookingAsyncKey.Async}", Method.GET);
            Request.AddHeader("From", Config.ApiKey);
            Request.AddHeader("Date", dateTime.ToString("r"));
            Request.AddHeader("Authorization", signature);
            Request.AddHeader("Api-Locale", "zh-CN");

            var response = _client.Execute<BookingResponse>(Request);
            var count = 0;

            //資料若未Ready, 就Sleep再重試
            while (response.Content.Equals("{\"description\":\"Async result not ready.\"}") && count < 10)
            {
                Thread.Sleep(5000);
                response = _client.Execute<BookingResponse>(Request);
                count++;
            }
            Response = response;
            return response.Data;
        }
    }



    public class SearchAsync
    {
        public string Async { get; set; }
    }
}