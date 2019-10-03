using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.Models.ViewModels.Nba
{
    public class NbaScoreBaseVM
    {
        public string Points { get; set; }

        public NbaScoreBaseVM(NbaScoreBase s)
        {
            Points = s.Points;
        }

        public NbaScoreBaseVM() { }
    }
}
