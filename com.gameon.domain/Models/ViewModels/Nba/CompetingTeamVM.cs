using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.Models.ViewModels.Nba
{
    public class CompetingTeamVM : NbaTeamBaseVM
    {
        public NbaScoreBaseVM Score { get; set; }

        public CompetingTeamVM(CompetingTeam c)
        {
            FullName = c.FullName;
            TeamId = c.TeamId;
            NickName = c.NickName;
            ShortName = c.ShortName;
            Logo = c.Logo;
            Score = (c.Score != null) ? new NbaScoreBaseVM(c.Score) : null;
        }
    }
}
