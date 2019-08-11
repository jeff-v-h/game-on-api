using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class TournamentRound
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("number")]
        public int? Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cup_round_match_number")]
        public int? CupRoundMatchNumber { get; set; }

        [JsonProperty("cup_round_matches")]
        public int? CupRoundMatches { get; set; }
    }
}
