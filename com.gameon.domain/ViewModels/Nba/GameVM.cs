using com.gameon.data.ThirdPartyApis.Models.Nba;
using System;

namespace com.gameon.domain.ViewModels.Nba
{
    public class GameVM
    {
        public string SeasonYear { get; set; }
        public string League { get; set; }
        public string GameId { get; set; }
        public DateTime? StartTimeUTC { get; set; }
        public DateTime? EndTimeUTC { get; set; }
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
        public CompetingTeamVM VTeam { get; set; }
        public CompetingTeamVM HTeam { get; set; }

        public GameVM(Game g)
        {
            SeasonYear = g.SeasonYear;
            League = g.League;
            GameId = g.GameId;
            StartTimeUTC = g.StartTimeUTC;
            EndTimeUTC = g.EndTimeUTC;
            Arena = g.Arena;
            City = g.City;
            Country = g.Country;
            Clock = g.Clock;
            GameDuration = g.GameDuration;
            CurrentPeriod = g.CurrentPeriod;
            Halftime = g.Halftime;
            EndOfPeriod = g.EndOfPeriod;
            SeasonStage = g.SeasonStage;
            StatusShortGame = g.StatusShortGame;
            StatusGame = g.StatusGame;
            VTeam = (g.VTeam != null) ? new CompetingTeamVM(g.VTeam) : null;
            HTeam = (g.HTeam != null) ? new CompetingTeamVM(g.HTeam) : null;
        }
    }
}
