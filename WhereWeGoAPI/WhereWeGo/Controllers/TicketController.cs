using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Utility.Logging;
using WhereWeGo.DTOs.GrailTravel.SDK.Response.Confirm;
using WhereWeGoAPI.DTOs;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Requests;
using WhereWeGoAPI.DTOs.GrailTravel.SDK.Response.Booking;
using WhereWeGoAPI.Models.Interfaces;

namespace WhereWeGoAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("Ticket")]
    public class TicketController : ApiController
    {
        #region members
        private readonly ILogger _logger;
        private readonly IJourneyService _journeyService;
        private readonly IIssueTicketService _issueTicketSvc;
        private readonly ICheckOutService _checkOutSvc;
        #endregion

        #region Property
        public ILogger Logger => this._logger;
        public IJourneyService JourneyService => this._journeyService;
        public IIssueTicketService IssueTicketService => this._issueTicketSvc;
        public ICheckOutService CheckOutService => this._checkOutSvc;
        #endregion

        #region Constructor
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
        #endregion

        [HttpGet]
        [Route("LoadingJourneys")]
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
        [ResponseType(typeof(BookingResponse))]
        [Route("Booking")]
        public async Task<IHttpActionResult> Booking([FromBody]Booking bookInfo)
        {
            BookingResponse result = null;

            try
            {
                result = this._checkOutSvc.BookTraveling(bookInfo);
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message);
                return InternalServerError(ex);
            }

            return Ok(result);
        }

        [HttpPost]
        [ResponseType(typeof(ConfirmResponse))]
        [Route("Payment")]
        public async Task<IHttpActionResult> Payment(Payment payment)
        {
            ConfirmResponse resp = null;

            try
            {
                resp = this._checkOutSvc.Pay(
                        payment.BookingId,
                        new ConfirmRequest { credit_card = payment.CreditCard }
                    );
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message);
                return InternalServerError(ex);
            }

            return Ok(resp);
        }

        [HttpPost]
        [Route("IssueTicket")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> IssueTicket()
        {
            string downloadUrl = string.Empty;

            try
            {
                downloadUrl = this._issueTicketSvc.Download();
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message);
                return InternalServerError(ex);
            }

            return Ok(downloadUrl);
        }

    }
}
