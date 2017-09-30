namespace WhereWeGoAPI.Models.Interfaces
{
    public interface IIssueTicketService
    {
        byte[] TicketFile { get; }

        string Download();
    }
}
