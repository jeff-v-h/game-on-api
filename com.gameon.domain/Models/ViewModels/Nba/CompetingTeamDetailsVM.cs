using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Nba
{
    public class CompetingTeamDetailsVM : NbaTeamBaseVM
    {
        public string AllStar;
        public string NbaFranchise;
        public NbaScoreVM Score;
        public List<StatsLeaderVM> Leaders;
    }
}
