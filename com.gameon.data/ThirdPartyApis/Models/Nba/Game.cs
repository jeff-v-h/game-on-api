using System;

namespace com.gameon.data.ThirdPartyApis.Models.Nba
{
    public class Game
    {
        public string SeasonYear { get; set; }
        public string League { get; set; }
        public string GameId { get; set; }
        public DateTime StartTimeUTC { get; set; }
        public DateTime EndTimeUTC { get; set; }
        public string Arena { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Clock { get; set; }
        public string GameDuration { get; set; }
        public string CurrentPeriod { get; set; }
        public string Halftime { get; set; }
        public string EndOfPeriod { get; set; }
        public string SeasonStage { get; set; }
        public string StatusShortGame { get; set; }
        public string StatusGame { get; set; }
        public CompetingTeam VTeam { get; set; }
        public CompetingTeam HTeam { get; set; }
    }
}
