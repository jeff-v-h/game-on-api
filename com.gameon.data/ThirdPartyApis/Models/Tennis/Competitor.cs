using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class Competitor : Player
    {
        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("seed")]
        public int? Seed { get; set; }

        [JsonProperty("bracket_number")]
        public int? BracketNumber { get; set; }

        [JsonProperty("qualifier")]
        public string Qualifier { get; set; }

        [JsonProperty("qualification_path")]
        public string QualificationPath { get; set; }
    }
}
