using WhereWeGoAPI.Models.Interfaces;

namespace WhereWeGoAPI.Models.Implements
{
    public class IssueTicketService : IIssueTicketService
    {
        private byte[] _fileStream;

        byte[] IIssueTicketService.TicketFile => _fileStream;

        public string Download()
        {
            return string.Empty;
        }
    }
}