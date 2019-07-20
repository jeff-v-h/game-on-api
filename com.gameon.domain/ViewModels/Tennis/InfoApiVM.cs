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
        public PlayerBaseVM WinnerLastSeason { get; set; }
        public List<TennisCompetitorVM> Competitors { get; set; }
        public List<StageVM> Stages { get; set; }

        public InfoApiVM(InfoApi i)
        {
            GeneratedAt = i.GeneratedAt;
            Schema = i.Schema;
            Tournament = (i.Tournament != null) ? new TournamentVM(i.Tournament) : null;
            Season = (i.Season != null) ? new SeasonVM(i.Season) : null;
            TournamentRound = (i.TournamentRound != null) ? new TournamentRoundVM(i.TournamentRound) : null;
            Info = (i.Info != null) ? new InfoVM(i.Info) : null;
            CoverageInfo = (i.CoverageInfo != null) ? new CoverageInfoVM(i.CoverageInfo) : null;
            WinnerLastSeason = (i.WinnerLastSeason != null) ? new PlayerBaseVM(i.WinnerLastSeason) : null;
            Competitors = MapCompetitors(i.Competitors);
            Stages = MapStages(i.Stages);
        }

        private List<TennisCompetitorVM> MapCompetitors(List<TennisCompetitor> competitors)
        {
            if (competitors == null) return null;

            var list = new List<TennisCompetitorVM>();

            for (int i = 0; i < competitors.Count; i++)
            {
                list.Add(new TennisCompetitorVM(competitors[i]));
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
