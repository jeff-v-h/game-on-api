namespace com.gameon.data.ThirdPartyApis.Models.Nba
{
    public class NbaGame : NbaGameBase
    {
        public CompetingTeam VTeam { get; set; }
        public CompetingTeam HTeam { get; set; }
    }
}
