using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{
    public class SportEvent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("scheduled")]
        public DateTime? Scheduled { get; set; }

        [JsonProperty("start_time_tbd")]
        public bool StartTimeTbd { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tournament_round")]
        public TournamentRound TournamentRound { get; set; }

        [JsonProperty("season")]
        public Season Season { get; set; }

        [JsonProperty("tournament")]
        public Tournament Tournament { get; set; }

        [JsonProperty("competitors")]
        public List<Competitor> Competitors { get; set; }

        [JsonProperty("Venue")]
        public Venue Venue { get; set; }

        [JsonProperty("estimated")]
        public bool Estimated { get; set; }
    }


}
