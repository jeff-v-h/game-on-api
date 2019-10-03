using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.Models.ViewModels.Nba
{
    public class CompetingTeamVM : NbaTeamBaseVM
    {
        public NbaScoreBaseVM Score { get; set; }
    }
}
