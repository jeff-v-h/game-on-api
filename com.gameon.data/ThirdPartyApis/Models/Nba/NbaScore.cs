using System.Collections.Generic;

namespace com.gameon.data.ThirdPartyApis.Models.Nba
{
    public class NbaScore : NbaScoreBase
    {
        public string Win { get; set; }
        public string Loss { get; set; }
        public string SeriesWin { get; set; }
        public string SeriesLoss { get; set; }
        public List<string> LineScore { get; set; }
    }
}
