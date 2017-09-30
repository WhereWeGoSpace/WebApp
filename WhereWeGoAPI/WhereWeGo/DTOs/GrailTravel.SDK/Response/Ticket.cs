namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Response
{
    public class Ticket
    {
        public string id { get; set; }
        public From from { get; set; }
        public To to { get; set; }
        public Price price { get; set; }
    }
}