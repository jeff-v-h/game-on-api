using Newtonsoft.Json;
using System;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Competition
    {
        [JsonProperty("winner_type")]
        public string WinnerType { get; set; }

        [JsonProperty("winner_id")]
        public int? WinnerId { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [JsonProperty("league_id")]
        public int LeagueId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }

        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; set; }
    }
}
