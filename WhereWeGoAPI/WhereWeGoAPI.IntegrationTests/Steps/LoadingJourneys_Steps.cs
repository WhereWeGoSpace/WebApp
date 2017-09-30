using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WhereWeGoAPI.Controllers;
using WhereWeGoAPI.DTOs;
using WhereWeGoAPI.IntegrationTests.Factories;

namespace WhereWeGoAPI.IntegrationTests.Steps
{
    [Binding]
    public sealed class LoadingJourneys_Steps
    {
        private static TicketController _ctrl;

        [BeforeFeature]
        public static void SetUp()
        {
            _ctrl = ControllerFactory.GetTicketController();
        }

        [Given(@"There are a hot traveling result")]
        public void GivenThereAreAHotTravelingResult(Table table)
        {
            IEnumerable<Traveling> ieTr = table.CreateSet<Traveling>();
            ScenarioContext.Current.Add("ori_result", ieTr);

            _ctrl.JourneyService.SetTravelings(ieTr);
        }

        [When(@"user click bar")]
        public async Task WhenUserClickBar()
        {
            var result = (await _ctrl.LoadingJourneys()) as OkNegotiatedContentResult<Traveling>;

            Traveling tr = result.Content;

            ScenarioContext.Current.Add("final_result", tr);
        }

        [Then(@"show one random result")]
        public void ThenShowOneRandomResult()
        {
            var actual = ScenarioContext.Current["final_result"] as Traveling;

            var expect = ScenarioContext.Current["ori_result"] as IEnumerable<Traveling>;
            expect.Contains(actual).Should().BeTrue();
        }

    }
}
