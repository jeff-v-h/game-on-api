using Newtonsoft.Json;
using System;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Event
    {
        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; set; }

        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }

        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("stream_url")]
        public string StreamUrl { get; set; }

        [JsonProperty("tournament_id")]
        public int TournamentId { get; set; }
    }
}
