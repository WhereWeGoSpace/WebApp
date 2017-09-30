using Newtonsoft.Json;

namespace WhereWeGo.DTOs.GrailTravel.SDK.Requests
{
    public class ConfirmRequest : RequestBase
    {
        public CreditCard credit_card { get; set; }

    }

    public class ConfirmRequestForSecure : RequestBase
    {
        public CreditCard credit_card { get; set; }

        [JsonProperty("online_order_id")]
        public string online_order_id { get; set; }
    }

    public class CreditCard
    {
        [JsonProperty("number")]
        public string number { get; set; }
        [JsonProperty("exp_month")]
        public int exp_month { get; set; }
        [JsonProperty("exp_year")]
        public int exp_year { get; set; }
        [JsonProperty("cvv")]
        public string cvv { get; set; }
    }
}