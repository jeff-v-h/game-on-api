using com.gameon.data.ThirdPartyApis.Models.Nba;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Nba
{
    public class CompetingTeamDetailsVM : NbaTeamBaseVM
    {
        public string AllStar;
        public string NbaFranchise;
        public NbaScoreVM Score;
        public List<StatsLeaderVM> Leaders;

        public CompetingTeamDetailsVM(CompetingTeamDetails c)
        {
            FullName = c.FullName;
            TeamId = c.TeamId;
            NickName = c.NickName;
            Logo = c.Logo;
            ShortName = c.ShortName;
            AllStar = c.AllStar;
            NbaFranchise = c.NbaFranchise;
            Score = (c.Score != null) ? new NbaScoreVM(c.Score) : null;
            Leaders = MapLeaders(c.Leaders);
        }

        private List<StatsLeaderVM> MapLeaders(List<StatsLeader> leaders)
        {
            if (leaders == null) return null;

            var list = new List<StatsLeaderVM>();

            for (int i = 0; i < leaders.Count; i++)
                list.Add(new StatsLeaderVM(leaders[i]));

            return list;
        }
    }
}
