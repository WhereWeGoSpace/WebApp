using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using RestSharp;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Booking;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Confirm;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Search;

namespace WhereWeGoAPI.Models.GrailTravel.SDK
{
    public class DetieClient : IDetieClient
    {
        private readonly IRestClient _client;
        private readonly int sleepSecond = 5;
        private readonly int retryMaxCount = 20;
        public DetieClient()
        {
            _client = new RestClient(Config.GrailTravelHost);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public IRestRequest Request { get; set; }

        public IRestResponse Response { get; set; }

        public AsyncKey Search(SearchRequest searchReqeust)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, searchReqeust);
            var signature = secure.Sign();

            Request = new RestRequest($"api/v2/online_solutions?{searchReqeust.GetURL()}", Method.GET);
            Request.AddHeader("From", Config.ApiKey);
            Request.AddHeader("Date", dateTime.ToString("r"));
            Request.AddHeader("Authorization", signature);
            Request.AddHeader("Api-Locale", "zh-CN");

            var response = _client.Execute<AsyncKey>(Request);
            Response = response;
            return response.Data;
        }

        public string Search_Async(AsyncKey asyncKey)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var request = new SearchRequestAsync { AsyncKey = asyncKey.Async };
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, request);
            var signature = secure.Sign();

            Request = new RestRequest($"api/v2/async_results/{asyncKey.Async}", Method.GET);
            Request.AddHeader("From", Config.ApiKey);
            Request.AddHeader("Date", dateTime.ToString("r"));
            Request.AddHeader("Authorization", signature);
            Request.AddHeader("Api-Locale", "zh-CN");

            var response = _client.Execute<List<SearchResponse>>(Request);
            var count = 0;

            //資料若未Ready, 就Sleep再重試
            while (response.Content.Equals("{\"description\":\"Async result not ready.\"}") && count < retryMaxCount)
            {
                Thread.Sleep(sleepSecond * 1000);
                response = _client.Execute<List<SearchResponse>>(Request);
                count++;
            }
            Response = response;
            return response.Content;
        }

        public AsyncKey Booking(BookingRequest bookingRequest)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, bookingRequest);
            var signature = secure.Sign();

            Request = new RestRequest($"api/v2/online_orders", Method.POST) { RequestFormat = DataFormat.Json };
            Request.AddBody(bookingRequest);
            Request.AddHeader("Content-Type", "application/json");
            Request.AddHeader("From", Config.ApiKey);
            Request.AddHeader("Date", dateTime.ToString("r"));
            Request.AddHeader("Authorization", signature);
            Request.AddHeader("Api-Locale", "zh-CN");

            var response = _client.Execute<AsyncKey>(Request);
            Response = response;
            return response.Data;
        }

        public BookingResponse Booking_Async(AsyncKey bookingAsyncKeyKey)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var request = new SearchRequestAsync { AsyncKey = bookingAsyncKeyKey.Async };
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, request);
            var signature = secure.Sign();

            Request = new RestRequest($"api/v2/async_results/{bookingAsyncKeyKey.Async}", Method.GET);
            Request.AddHeader("From", Config.ApiKey);
            Request.AddHeader("Date", dateTime.ToString("r"));
            Request.AddHeader("Authorization", signature);
            Request.AddHeader("Api-Locale", "zh-CN");

            var response = _client.Execute<BookingResponse>(Request);
            var count = 0;

            //資料若未Ready, 就Sleep再重試
            while (response.Content.Equals("{\"description\":\"Async result not ready.\"}") && count < retryMaxCount)
            {
                Thread.Sleep(sleepSecond * 1000);
                response = _client.Execute<BookingResponse>(Request);
                count++;
            }
            Response = response;
            return response.Data;
        }

        public AsyncKey Confirm(string onLineOrderId, ConfirmRequest confirmRequest)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, new ConfirmRequestForSecure { credit_card = confirmRequest.credit_card, online_order_id = onLineOrderId });

            var signature = secure.Sign();

            Request = new RestRequest($"api/v2/online_orders/{onLineOrderId}/online_confirmations", Method.POST) { RequestFormat = DataFormat.Json };

            Request.AddBody(confirmRequest);
            Request.AddHeader("Content-Type", "application/json");
            Request.AddHeader("From", Config.ApiKey);
            Request.AddHeader("Date", dateTime.ToString("r"));
            Request.AddHeader("Authorization", signature);
            Request.AddHeader("Api-Locale", "zh-CN");

            var response = _client.Execute<AsyncKey>(Request);
            Response = response;
            return response.Data;
        }

        public ConfirmResponse Confirm_Async(AsyncKey confirmAsyncKeyKey)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var request = new SearchRequestAsync { AsyncKey = confirmAsyncKeyKey.Async };
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, request);
            var signature = secure.Sign();

            Request = new RestRequest($"api/v2/async_results/{confirmAsyncKeyKey.Async}", Method.GET);
            Request.AddHeader("From", Config.ApiKey);
            Request.AddHeader("Date", dateTime.ToString("r"));
            Request.AddHeader("Authorization", signature);
            Request.AddHeader("Api-Locale", "zh-CN");

            var response = _client.Execute<ConfirmResponse>(Request);
            var count = 0;

            //資料若未Ready, 就Sleep再重試
            while (response.Content.Equals("{\"description\":\"Async result not ready.\"}") && count < retryMaxCount)
            {
                Thread.Sleep(sleepSecond * 1000);
                response = _client.Execute<ConfirmResponse>(Request);
                count++;
            }
            Response = response;
            return response.Data;
        }

        public string Download(string onLineOrderId)
        {
            var dateTime = DateTime.Now.ToUniversalTime();
            var secure = new ParamSecure(Config.Secret, Config.ApiKey, dateTime, new DownloadRequestForSecure { online_order_id = onLineOrderId });

            var signature = secure.Sign();

            Request = new RestRequest($"/v2/online_orders/{onLineOrderId}/online_tickets", Method.GET) { RequestFormat = DataFormat.Json };

            Request.AddHeader("Content-Type", "application/json");
            Request.AddHeader("From", Config.ApiKey);
            Request.AddHeader("Date", dateTime.ToString("r"));
            Request.AddHeader("Authorization", signature);
            Request.AddHeader("Api-Locale", "zh-CN");

            var response = _client.Execute(Request);
            Response = response;
            return response.Content;
        }
    }


    public class AsyncKey
    {
        public string Async { get; set; }
    }
}