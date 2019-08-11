using Newtonsoft.Json;
using System;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Endpoint
    {
        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; set; }

        [JsonProperty("expected_begin_at")]
        public DateTime? ExpectedBeginAt { get; set; }

        [JsonProperty("last_active")]
        public DateTime? LastActive { get; set; }

        [JsonProperty("match_id")]
        public int MatchId { get; set; }

        [JsonProperty("open")]
        public bool Open { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
