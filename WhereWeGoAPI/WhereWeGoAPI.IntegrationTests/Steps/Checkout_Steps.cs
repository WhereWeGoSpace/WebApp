using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WhereWeGo.Controllers;
using WhereWeGo.DTOs;
using WhereWeGo.DTOs.GrailTravel.SDK.Requests;
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

            Booking bookInfo = new Booking {
                From_Code =tr.From_Code, To_Code=tr.To_Code,
                Contactor = new Contact
                {
                    address = "beijing",
                    email = "lp@163.com",
                    name = "Liping",
                    phone = "10086",
                    postcode = "100100"
                },
                Passengers = new List<Passenger>
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
                }
            };

            var result = (await _ctrl.Booking(bookInfo)) as OkNegotiatedContentResult<bool>;
            bool booking_result = result.Content;

            ScenarioContext.Current.Add("booking_result", booking_result);
        }

        [When(@"user pays")]
        public async Task WhenUserPays()
        {
            BookingRequest bookingResult = ScenarioContext.Current["booking_result"] as BookingRequest;

            var result = (await _ctrl.Payment()) as OkNegotiatedContentResult<bool>;
            bool payment_result = result.Content;

            ScenarioContext.Current.Add("payment_result", payment_result);
        }

        [Then(@"booking is ok")]
        public void ThenBookingIsOk()
        {
            bool execution_result = (bool)ScenarioContext.Current["payment_result"];

            execution_result.Should().BeTrue();
        }


    }
}
