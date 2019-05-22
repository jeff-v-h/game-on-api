using Newtonsoft.Json;
using System;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Match
    {
        [JsonProperty("winner_id")]
        public int? WinnerId { get; set; }

        [JsonProperty("tournament_id")]
        public int TournamentId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("number_of_games")]
        public int NumberOfGames { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [JsonProperty("match_type")]
        public string MatchType { get; set; }

        [JsonProperty("live")]
        public Live Live { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("forfeit")]
        public bool Forfeit { get; set; }

        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }

        [JsonProperty("draw")]
        public bool Draw { get; set; }

        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; set; }
    }
}
