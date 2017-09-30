using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WhereWeGo.DTOs.GrailTravel.SDK.Response.Confirm;
using WhereWeGoAPI.Controllers;
using WhereWeGoAPI.DTOs;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Booking;
using WhereWeGoAPI.IntegrationTests.Factories;

namespace WhereWeGoAPI.IntegrationTests.Steps
{
    [Binding]
    public sealed class Checkout_Steps
    {
        private static TicketController _ctrl;

        [BeforeFeature]
        public static void SetUp()
        {
            _ctrl = ControllerFactory.GetTicketController();
        }

        [Given(@"There is a favorit traveling")]
        public void GivenThereIsAFavoritTraveling(Table table)
        {
            Traveling tr = table.CreateSet<Traveling>().ElementAt(0);

            ScenarioContext.Current.Add("favorit_traveling", tr);
        }

        [When(@"user books")]
        public async Task WhenUserBooks()
        {
            Traveling tr = ScenarioContext.Current["favorit_traveling"] as Traveling;

            Booking bookInfo = new Booking
            {
                From_Code = tr.From_Code,
                To_Code = tr.To_Code,
                Contactor = new Contact
                {
                    address = "beijing",
                    email = "lp@163.com",
                    name = "Liping",
                    phone = "10086",
                    postcode = "100100"
                },
                Passengers = new List<DTOs.GrailTravel.SDK.Requests.Passenger>
                {
                    new DTOs.GrailTravel.SDK.Requests.Passenger
                    {
                        last_name = "zhang",
                        first_name = "san",
                        birthdate = "1986-09-01",
                        passport = "A123456",
                        email = "x@a.cn",
                        phone = "15000367081",
                        gender = "male"
                    }
                }
            };

            var result = (await _ctrl.Booking(bookInfo)) as OkNegotiatedContentResult<BookingResponse>;
            BookingResponse booking_result = result.Content;

            ScenarioContext.Current.Add("bookingId", booking_result.id);
        }

        [When(@"user fill up the credit card info")]
        public async Task WhenUserFillUpTheCreditCardInfo(Table table)
        {
            string bookingId = ScenarioContext.Current["bookingId"] as string;

            Payment payment = new Payment
            {
                BookingId = bookingId,
                CreditCard = table.CreateSet<CreditCard>().ElementAt(0)
            };

            var result = (await _ctrl.Payment(payment)) as OkNegotiatedContentResult<ConfirmResponse>;
            ConfirmResponse payment_result = result.Content;

            ScenarioContext.Current.Add("payment_result", payment_result);
        }

        [Then(@"booking is ok")]
        public void ThenBookingIsOk()
        {
            ConfirmResponse execution_result = ScenarioContext.Current["payment_result"] as ConfirmResponse;

            execution_result.Should().NotBeNull();
        }


    }
}
