using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.ViewModels.Nba
{
    public class LeaguesVM
    {
        public StandardVM Standard { get; set; }

        public LeaguesVM(Leagues l)
        {
            Standard = new StandardVM(l.Standard);
        }
    }
}
