using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models
{
    public class ProMatch
    {
        [JsonProperty("match_id")]
        public long match_id { get; set; }

        [JsonProperty("duration")]
        public int duration { get; set; }

        [JsonProperty("start_time")]
        public int start_time { get; set; }

        [JsonProperty("radiant_team_id")]
        public int radiant_team_id { get; set; }

        [JsonProperty("radiant_name")]
        public string radiant_name { get; set; }

        [JsonProperty("dire_team_id")]
        public int dire_team_id { get; set; }

        [JsonProperty("dire_name")]
        public string dire_name { get; set; }

        [JsonProperty("leagueid")]
        public int leagueid { get; set; }

        [JsonProperty("league_name")]
        public string league_name { get; set; }

        [JsonProperty("series_id")]
        public int series_id { get; set; }

        [JsonProperty("series_type")]
        public int series_type { get; set; }

        [JsonProperty("radiant_score")]
        public int radiant_score { get; set; }

        [JsonProperty("dire_score")]
        public int dire_score { get; set; }

        [JsonProperty("radiant_win")]
        public bool radiant_win { get; set; }
    }
}
