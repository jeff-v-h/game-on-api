using com.gameon.data.ThirdPartyApis.Models.Nba;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Nba
{
    public class NbaScoreVM : NbaScoreBaseVM
    {
        public string Win { get; set; }
        public string Loss { get; set; }
        public string SeriesWin { get; set; }
        public string SeriesLoss { get; set; }
        public List<string> LineScore { get; set; }

        public NbaScoreVM(NbaScore s)
        {
            Win = s.Win;
            Loss = s.Loss;
            SeriesWin = s.SeriesWin;
            SeriesLoss = s.SeriesLoss;
            LineScore = s.LineScore;
        }
    }
}
