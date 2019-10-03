using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Nba
{
    public class NbaGameDetailsVM : NbaGameBaseVM
    {
        public CompetingTeamDetailsVM VTeam { get; set; }
        public CompetingTeamDetailsVM HTeam { get; set; }
        public List<OfficialVM> Officials { get; set; }
    }
}
