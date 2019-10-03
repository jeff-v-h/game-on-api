namespace com.gameon.domain.Models.ViewModels.Nba
{
    public class NbaTeamVM : NbaTeamBaseVM
    {
        public string City { get; set; }
        public string NbaFranchise { get; set; }
        public string AllStar { get; set; }
        public LeaguesVM Leagues { get; set; }
    }
}
