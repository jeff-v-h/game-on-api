using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.ViewModels.Nba
{
    public class TeamVM : TeamBaseVM
    {
        public string City { get; set; }
        public string NbaFranchise { get; set; }
        public string AllStar { get; set; }
        public LeaguesVM Leagues { get; set; }

        public TeamVM(Team t)
        {
            FullName = t.FullName;
            TeamId = t.TeamId;
            NickName = t.NickName;
            ShortName = t.ShortName;
            Logo = t.Logo;
            City = t.City;
            NbaFranchise = t.NbaFranchise;
            AllStar = t.AllStar;
            Leagues = new LeaguesVM(t.Leagues);
        }
    }
}
