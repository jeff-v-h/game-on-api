using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Tennis
{
    public class StageVM
    {
        public string Type { get; set; }
        public List<TennisCompetitorVM> Competitors { get; set; }
        public int? NumberOfScheduledMatches { get; set; }
    }
}
