namespace com.gameon.data.ThirdPartyApis.Models.Nba
{
    public class Team : TeamBase
    {
        public string City { get; set; }
        public string NbaFranchise { get; set; }
        public string AllStar { get; set; }
        public Leagues Leagues { get; set; }
    }
}
