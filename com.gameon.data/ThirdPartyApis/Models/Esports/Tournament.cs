using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Tournament
    {
        [JsonProperty("winner_type")]
        public string WinnerType { get; set; }

        [JsonProperty("winner_id")]
        public int? WinnerId { get; set; }

        [JsonProperty("videogame")]
        public VideoGame VideoGame { get; set; }

        [JsonProperty("teams")]
        public List<TeamBase> Teams { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("serie_id")]
        public int SeriesId { get; set; }

        [JsonProperty("serie")]
        public Series Series { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [JsonProperty("matches")]
        public List<Match> Matches { get; set; }

        [JsonProperty("league_id")]
        public int LeagueId { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("end_at")]
        public DateTime? EndAt { get; set; }

        [JsonProperty("begin_at")]
        public DateTime? BeginAt { get; set; }
    }
}
