using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.Models.ViewModels.Nba
{
    public class LeaguesVM
    {
        public StandardVM Standard { get; set; }

        public LeaguesVM(Leagues l)
        {
            Standard = (l.Standard != null) ? new StandardVM(l.Standard) : null;
        }
    }
}
