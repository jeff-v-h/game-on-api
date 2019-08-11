using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Nba
{
    public class CompetingTeamDetails : NbaTeamBase
    {
        public string AllStar { get; set; }
        public string NbaFranchise { get; set; }
        public NbaScore Score { get; set; }
        public List<StatsLeader> Leaders { get; set; }
    }
}
