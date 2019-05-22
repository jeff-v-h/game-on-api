using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.ViewModels.Nba
{
    public class CompetingTeamVM : NbaTeamBaseVM
    {
        public NbaScoreVM Score { get; set; }

        public CompetingTeamVM(CompetingTeam c)
        {
            FullName = c.FullName;
            TeamId = c.TeamId;
            NickName = c.NickName;
            ShortName = c.ShortName;
            Logo = c.Logo;
            Score = (c.Score != null) ? new NbaScoreVM(c.Score) : null;
        }
    }
}
