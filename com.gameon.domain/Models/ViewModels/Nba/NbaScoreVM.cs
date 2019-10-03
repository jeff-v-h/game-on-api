using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.Nba
{
    public class NbaScoreVM : NbaScoreBaseVM
    {
        public string Win { get; set; }
        public string Loss { get; set; }
        public string SeriesWin { get; set; }
        public string SeriesLoss { get; set; }
        public List<string> LineScore { get; set; }
    }
}
