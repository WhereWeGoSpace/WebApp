using WhereWeGoAPI.Models.GrailTravel.SDK;
using WhereWeGoAPI.Models.Interfaces;

namespace WhereWeGoAPI.Models.Implements
{
    public class IssueTicketService : IIssueTicketService
    {
        private readonly IDetieClient _client;

        public IssueTicketService()
        {
            this._client = new DetieClient();
        }

        public IssueTicketService(IDetieClient client)
        {
            this._client = client;
        }

        public string Download(string orderId)
        {
            string downloadUrl = string.Empty;

            downloadUrl = this._client.Download(orderId);

            return downloadUrl;
        }
    }
}