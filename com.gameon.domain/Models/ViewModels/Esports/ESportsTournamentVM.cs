using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class EsportsTournamentVM : TournamentBaseVM
    {
        public List<EsportsTeamBaseVM> Teams { get; set; }
        public SeriesBaseVM Series { get; set; }
        public List<MatchBaseVM> Matches { get; set; }
        public LeagueVM League { get; set; }
    }
}
