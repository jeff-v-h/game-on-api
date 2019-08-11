using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Series : SeriesBase
    {
        [JsonProperty("videogame")]
        public VideoGame VideoGame { get; set; }

        [JsonProperty("tournaments")]
        public List<TournamentBase> Tournaments { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }
    }
}
