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
            var result = (await _ctrl.Booking(tr.From_Code, tr.To_Code)) as OkNegotiatedContentResult<bool>;
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
