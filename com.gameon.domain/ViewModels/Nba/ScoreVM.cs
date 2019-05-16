using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.ViewModels.Nba
{
    public class ScoreVM
    {
        public string Points { get; set; }

        public ScoreVM(Score s)
        {
            Points = s.Points;
        }
    }
}
