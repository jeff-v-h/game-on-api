using com.gameon.data.ThirdPartyApis.Models.Esports;

namespace com.gameon.domain.Models.ViewModels.Esports
{
    public class ResultVM
    {
        public int TeamId { get; set; }
        public int Score { get; set; }

        public ResultVM(Result r)
        {
            TeamId = r.TeamId;
            Score = r.Score;
        }
    }
}
