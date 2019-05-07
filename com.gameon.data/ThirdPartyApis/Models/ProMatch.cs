using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models
{
    public class ProMatch
    {
        [JsonProperty("match_id")]
        public long MatchId { get; set; }

        [JsonProperty("duration")]
        public int? Duration { get; set; }

        [JsonProperty("start_time")]
        public int? StartTime { get; set; }

        [JsonProperty("radiant_team_id")]
        public int? RadiantTeamId { get; set; }

        [JsonProperty("radiant_name")]
        public string RadiantName { get; set; }

        [JsonProperty("dire_team_id")]
        public int? DireTeamId { get; set; }

        [JsonProperty("dire_name")]
        public string DireName { get; set; }

        [JsonProperty("leagueid")]
        public int? LeagueId { get; set; }

        [JsonProperty("league_name")]
        public string LeagueName { get; set; }

        [JsonProperty("series_id")]
        public int SeriesId { get; set; }

        [JsonProperty("series_type")]
        public int? SeriesType { get; set; }

        [JsonProperty("radiant_score")]
        public int? RadiantScore { get; set; }

        [JsonProperty("dire_score")]
        public int? DireScore { get; set; }

        [JsonProperty("radiant_win")]
        public bool RadiantWin { get; set; }
    }
}
