using System;

namespace WhereWeGo.Models.Interfaces
{
    public interface IIssueTicketService
    {
        byte[] TicketFile { get; }

        void Download(DateTime? paidTime = null, DateTime? downloadTime = null);
    }
}
