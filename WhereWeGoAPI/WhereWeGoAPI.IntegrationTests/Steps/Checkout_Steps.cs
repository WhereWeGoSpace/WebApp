using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WhereWeGo.Controllers;
using WhereWeGo.DTOs;
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

        [When(@"user books and pays \$""(.*)""")]
        public async Task WhenUserBooksAndPays(int amount, Table table)
        {
            UserInfo userInfo = table.CreateSet<UserInfo>().First();

            Traveling tr = ScenarioContext.Current["favorit_traveling"] as Traveling;
            TicketIssuing ticketIssueing = new TicketIssuing { Traveling = tr };

            var result = (await _ctrl.Checkout(ticketIssueing)) as OkNegotiatedContentResult<bool>;

            bool execution_result = result.Content;

            ScenarioContext.Current.Add("execution_result", execution_result);
        }

        [Then(@"display ""(.*)""")]
        public void ThenDisplay(string message)
        {
            bool result = (bool)ScenarioContext.Current["execution_result"];

            result.Should().BeTrue();
        }


    }
}
