using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Tennis
{
    public class StageVM
    {
        public string Type { get; set; }
        public List<CompetitorVM> Competitors { get; set; }
        public int? NumberOfScheduledMatches { get; set; }

        public StageVM(Stage s)
        {
            Type = s.Type;
            Competitors = MapCompetitors(s.Competitors);
            NumberOfScheduledMatches = s.NumberOfScheduledMatches;
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
    }
}
