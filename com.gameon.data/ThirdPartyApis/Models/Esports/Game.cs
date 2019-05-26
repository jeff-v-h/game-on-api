using Newtonsoft.Json;
using System;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Game
    {
        [JsonProperty("winner_type")]
        public string WinnerType { get; set; }

        [JsonProperty("winner")]
        public Winner Winner { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("match_id")]
        public int MatchId { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("forfeit")]
        public bool Forfeit { get; set; }

        [JsonProperty("finished")]
        public bool Finished { get; set; }

        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }

        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; set; }
    }
}
