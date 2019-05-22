using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Tennis
{

    public class InfoApiVM : ApiBaseVM
    {
        public TournamentVM Tournament { get; set; }
        public SeasonVM Season { get; set; }
        public TournamentRoundVM TournamentRound { get; set; }
        public InfoVM Info { get; set; }
        public CoverageInfoVM CoverageInfo { get; set; }
        public PlayerVM WinnerLastSeason { get; set; }
        public List<CompetitorVM> Competitors { get; set; }
        public List<StageVM> Stages { get; set; }

        public InfoApiVM(InfoApi i)
        {
            GeneratedAt = i.GeneratedAt;
            Schema = i.Schema;
            Tournament = new TournamentVM(i.Tournament);
            Season = new SeasonVM(i.Season);
            TournamentRound = new TournamentRoundVM(i.TournamentRound);
            Info = new InfoVM(i.Info);
            CoverageInfo = new CoverageInfoVM(i.CoverageInfo);
            WinnerLastSeason = new PlayerVM(i.WinnerLastSeason);
            Competitors = MapCompetitors(i.Competitors);
            Stages = MapStages(i.Stages);
        }

        private List<CompetitorVM> MapCompetitors(List<Competitor> competitors)
        {
            if (competitors == null) return null;

            var list = new List<CompetitorVM>();

            for (int i = 0; i < competitors.Count; i++)
            {
                list.Add(new CompetitorVM(competitors[i]));
            }

            return list;
        }
        private List<StageVM> MapStages(List<Stage> stages)
        {
            if (stages == null) return null;

            var list = new List<StageVM>();

            for (int i = 0; i < stages.Count; i++)
            {
                list.Add(new StageVM(stages[i]));
            }

            return list;
        }
    }
}
