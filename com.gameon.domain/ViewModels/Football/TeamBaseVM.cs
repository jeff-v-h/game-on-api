using com.gameon.data.ThirdPartyApis.Models.Football;

namespace com.gameon.domain.ViewModels.Football
{
    public class TeamBaseVM
    {
        public int? TeamId { get; set; }
        public string TeamName { get; set; }
        public string Logo { get; set; }

        public TeamBaseVM(FootballTeamBase t)
        {
            TeamId = t.TeamId;
            TeamName = t.TeamName;
            Logo = t.Logo;
        }
    }
}
