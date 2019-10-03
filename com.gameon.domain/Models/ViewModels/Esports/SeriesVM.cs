using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class SeriesVM : SeriesBaseVM
    {
        public LeagueVM League { get; set; }
        public List<TournamentBaseVM> Tournaments { get; set; }
    }
}
