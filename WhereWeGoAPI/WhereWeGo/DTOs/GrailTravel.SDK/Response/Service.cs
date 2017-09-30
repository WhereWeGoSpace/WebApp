namespace WhereWeGoAPI.DTOs.GrailTravel.SDK.Response
{
    public class Service
    {
        public string code { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public Available available { get; set; }
        public Price price { get; set; }
        public string booking_code { get; set; }
    }
}