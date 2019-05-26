using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Tournament : TournamentBase
    {
        [JsonProperty("videogame")]
        public VideoGame VideoGame { get; set; }

        [JsonProperty("teams")]
        public List<TeamBase> Teams { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("serie")]
        public SeriesBase Series { get; set; }

        [JsonProperty("matches")]
        public List<MatchBase> Matches { get; set; }
    }
}
