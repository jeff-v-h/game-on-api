using Newtonsoft.Json;
using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Tennis
{

    public class InfoApi : ApiBase
    {
        [JsonProperty("tournament")]
        public TennisTournament Tournament { get; set; }

        [JsonProperty("season")]
        public Season Season { get; set; }

        [JsonProperty("tournament_round")]
        public TournamentRound TournamentRound { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("coverage_info")]
        public CoverageInfo CoverageInfo { get; set; }

        [JsonProperty("winner_last_season")]
        public PlayerBase WinnerLastSeason { get; set; }

        [JsonProperty("competitors")]
        public List<TennisCompetitor> Competitors { get; set; }

        [JsonProperty("stages")]
        public List<Stage> Stages { get; set; }
    }
}
