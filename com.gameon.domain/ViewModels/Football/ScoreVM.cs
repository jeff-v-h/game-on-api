using com.gameon.data.ThirdPartyApis.Models.Football;

namespace com.gameon.domain.ViewModels.Football
{
    public class ScoreVM
    {
        public string Halftime { get; set; }
        public string Fulltime { get; set; }
        public object Extratime { get; set; }
        public object Penalty { get; set; }

        public ScoreVM(Score s)
        {
            Halftime = s.Halftime;
            Fulltime = s.Fulltime;
            Extratime = s.Extratime;
            Penalty = s.Penalty;
        }
    }
}
