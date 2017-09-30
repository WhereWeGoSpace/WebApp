using System;
using System.Threading.Tasks;
using System.Web.Http.Results;
using FluentAssertions;
using TechTalk.SpecFlow;
using WhereWeGoAPI.Controllers;
using WhereWeGoAPI.IntegrationTests.Factories;

namespace WhereWeGoAPI.IntegrationTests.Steps
{
    [Binding]
    public sealed class IssueTicket_Steps
    {
        private static TicketController _ctrl;

        [Given(@"I have paid for favorit traveling")]
        public static void GivenIHavePaidForFavoritTraveling()
        {
            _ctrl = ControllerFactory.GetTicketController();
        }

        [Given(@"paid time is ""(.*)""")]
        public void GivenPaidTimeIs(string dateTime)
        {
            DateTime paidTime = DateTime.Parse(dateTime);

            ScenarioContext.Current.Add("paidTime", paidTime);
        }

        [When(@"I download")]
        public async Task WhenIDownload()
        {
            var result = (await _ctrl.IssueTicket()) as OkNegotiatedContentResult<string>;

            string ticket = result.Content;

            ScenarioContext.Current.Add("ticket", ticket);
        }

        [Then(@"I get a PDF of ticket")]
        public void ThenIGetAPDFOfTicket()
        {
            var result = ScenarioContext.Current["ticket"] as string;
            result.Should().NotBeNull();
        }



    }
}
