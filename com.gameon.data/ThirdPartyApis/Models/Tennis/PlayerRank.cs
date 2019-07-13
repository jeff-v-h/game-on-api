using Newtonsoft.Json;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class PlayerRank
    {
        [JsonProperty("rank")]
        public int? Rank { get; set; }

        [JsonProperty("points")]
        public int? Points { get; set; }

        [JsonProperty("ranking_movement")]
        public int? RankingMovement { get; set; }

        [JsonProperty("tournaments_played")]
        public int? TournamentsPlayed { get; set; }

        [JsonProperty("player")]
        public Player Player { get; set; }
    }
}
