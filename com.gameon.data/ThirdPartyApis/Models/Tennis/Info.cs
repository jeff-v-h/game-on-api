using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class Info
    {
        [JsonProperty("prize_money")]
        public int? PrizeMoney { get; set; }

        [JsonProperty("prize_currency")]
        public string PrizeCurrency { get; set; }

        [JsonProperty("surface")]
        public string Surface { get; set; }

        [JsonProperty("complex")]
        public string Complex { get; set; }

        [JsonProperty("number_of_competitors")]
        public int? NumberOfCompetitors { get; set; }

        [JsonProperty("number_of_qualified_competitors")]
        public int? NumberOfQualifiedCompetitors { get; set; }

        [JsonProperty("number_of_scheduled_matches")]
        public int? NumberOfScheduledMatches { get; set; }
    }
}
