using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.Models.ViewModels.Nba
{
    public class NbaGameVM : NbaGameBaseVM
    {
        public CompetingTeamVM VTeam { get; set; }
        public CompetingTeamVM HTeam { get; set; }
    }
}
