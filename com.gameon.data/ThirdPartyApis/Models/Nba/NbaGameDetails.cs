using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Nba
{
    public class NbaGameDetails : NbaGameBase
    {
        public CompetingTeamDetails VTeam { get; set; }
        public CompetingTeamDetails HTeam { get; set; }

        public List<Official> Officials { get; set; }
    }
}
