using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class MatchVM : MatchBaseVM
    {
        public VideoGameVM VideoGame { get; set; }
        public TournamentBaseVM Tournament { get; set; }
        public EsportsTeamBaseVM Winner { get; set; }
        public int SeriesId { get; set; }
        public SeriesBaseVM Series { get; set; }
        public List<ResultVM> Results { get; set; }
        public List<EsportsCompetitorVM> Opponents { get; set; }
        public int LeagueId { get; set; }
        public LeagueVM League { get; set; }
        public List<EsportsGameVM> Games { get; set; }
    }
}
