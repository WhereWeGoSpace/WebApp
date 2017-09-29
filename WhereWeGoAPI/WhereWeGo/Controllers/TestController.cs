using System.Web.Http;
using Utility.Logging;
using WhereWeGo.Models;

namespace WhereWeGo.Controllers
{
    public class TestController : ApiController
    {
        public ILogger _logger;
        private readonly ITestService _testSvc;

        public TestController(ILogger logger, ITestService testSvc)
        {
            this._logger = logger;
            this._testSvc = testSvc;

        }
    }
}
