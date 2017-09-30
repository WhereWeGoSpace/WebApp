using System;
using WhereWeGo.Models.Interfaces;

namespace WhereWeGo.Models.Implements
{
    public class IssueTicketService : IIssueTicketService
    {
        private byte[] _fileStream;

        byte[] IIssueTicketService.TicketFile => _fileStream;

        public void Download(DateTime? paidTime = null, DateTime? downloadTime = null)
        {
            if (!paidTime.HasValue || !downloadTime.HasValue)
            {
                this._fileStream = new byte[1] { 0 };
                return;
            }

            DateTime pt = paidTime.Value;
            DateTime dt = downloadTime.Value;
            if (dt.Subtract(pt).Days >= 3)
                throw new Exceptions.TimeoutException();
        }
    }
}