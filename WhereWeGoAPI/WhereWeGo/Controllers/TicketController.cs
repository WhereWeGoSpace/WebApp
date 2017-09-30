using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Utility.Logging;
using WhereWeGo.DTOs;
using WhereWeGo.Models.Interfaces;

namespace WhereWeGo.Controllers
{
    public class TicketController : ApiController
    {
        public readonly ILogger _logger;
        private readonly IJourneyService _journeyService;
        private readonly IIssueTicketService _issueTicketSvc;
        private readonly ICheckOutService _checkOutSvc;

        public ILogger Logger => this._logger;
        public IJourneyService JourneyService => this._journeyService;
        public IIssueTicketService IssueTicketService => this._issueTicketSvc;
        public ICheckOutService CheckOutService => this._checkOutSvc;

        public TicketController(
            ILogger logger,
            IJourneyService journeySvc,
            IIssueTicketService issueTicketSvc,
            ICheckOutService checkOutSvc)
        {
            this._logger = logger;
            this._journeyService = journeySvc;
            this._issueTicketSvc = issueTicketSvc;
            this._checkOutSvc = checkOutSvc;
        }

        [HttpGet]
        [ResponseType(typeof(Traveling))]
        public async Task<IHttpActionResult> LoadingJourneys()
        {
            Traveling result = null;

            try
            {
                result = this._journeyService.GetRandomTraveling();
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message);
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        [HttpPost]
        [ResponseType(typeof(byte[]))]
        public async Task<IHttpActionResult> IssueTicket(DateTime? pt = null, DateTime? dt = null)
        {
            byte[] result = null;

            try
            {
                this._issueTicketSvc.Download(pt, dt);

                result = this._issueTicketSvc.TicketFile;
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message);
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Checkout([FromBody]TicketIssuing ticket)
        {
            bool result = default(bool);

            try
            {
                result = this._checkOutSvc.BookTraveling(ticket.Traveling, ticket.UserInfo);
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message);
                return InternalServerError(ex);
            }

            return Ok(result);
        }

    }
}
