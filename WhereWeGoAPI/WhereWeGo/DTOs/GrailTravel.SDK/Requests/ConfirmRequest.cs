namespace WhereWeGo.DTOs.GrailTravel.SDK.Requests
{
    public class ConfirmRequest : RequestBase
    {
        public CreditCard credit_card { get; set; }
    }

    public class CreditCard
    {
        public string number { get; set; }
        public int exp_month { get; set; }
        public int exp_year { get; set; }
        public string cvv { get; set; }
    }
}