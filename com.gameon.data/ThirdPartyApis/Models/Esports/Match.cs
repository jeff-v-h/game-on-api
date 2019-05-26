using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Esports
{
    public class Match : MatchBase
    {
        [JsonProperty("videogame_version")]
        public object VideoGameVersion { get; set; }

        [JsonProperty("tournament")]
        public TournamentBase Tournament { get; set; }

        [JsonProperty("winner")]
        public TeamBase Winner { get; set; }

        [JsonProperty("serie_id")]
        public int SeriesId { get; set; }

        [JsonProperty("serie")]
        public SeriesBase Series { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        [JsonProperty("opponents")]
        public List<Competitor> Opponents { get; set; }

        [JsonProperty("league_id")]
        public int LeagueId { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("games")]
        public List<Game> Games { get; set; }
    }
}
