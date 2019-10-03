using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class StageVM
    {
        public string Type { get; set; }
        public List<TennisCompetitorVM> Competitors { get; set; }
        public int? NumberOfScheduledMatches { get; set; }

        public StageVM(Stage s)
        {
            Type = s.Type;
            Competitors = MapCompetitors(s.Competitors);
            NumberOfScheduledMatches = s.NumberOfScheduledMatches;
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
    }
}
