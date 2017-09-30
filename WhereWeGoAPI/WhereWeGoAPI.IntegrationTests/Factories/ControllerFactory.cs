using NSubstitute;
using Utility.Logging;
using WhereWeGoAPI.Controllers;
using WhereWeGoAPI.Models.Implements;

namespace WhereWeGoAPI.IntegrationTests.Factories
{
    class ControllerFactory
    {
        public static TicketController GetTicketController()
        {
            TicketController ctrl = null;

            ILogger logger = Substitute.For<ILogger>();
            ctrl = new TicketController(logger,
                new JourneyService(),
                new IssueTicketService(),
                new CheckOutService());

            return ctrl;
        }
    }
}
