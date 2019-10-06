using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Tennis
{

    public class InfoApiVM : ApiBaseVM
    {
        public TournamentVM Tournament { get; set; }
        public SeasonVM Season { get; set; }
        public TournamentRoundVM TournamentRound { get; set; }
        public InfoVM Info { get; set; }
        public CoverageInfoVM CoverageInfo { get; set; }
        public PlayerBaseVM WinnerLastSeason { get; set; }
        public List<TennisCompetitorVM> Competitors { get; set; }
        public List<StageVM> Stages { get; set; }
    }
}
