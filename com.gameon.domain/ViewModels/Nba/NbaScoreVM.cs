using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.ViewModels.Nba
{
    public class NbaScoreVM
    {
        public string Points { get; set; }

        public NbaScoreVM(Score s)
        {
            Points = s.Points;
        }
    }
}
