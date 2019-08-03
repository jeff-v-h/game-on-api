using com.gameon.data.ThirdPartyApis.Models.Nba;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.Nba
{
    public class NbaGameDetailsVM : NbaGameBaseVM
    {
        public CompetingTeamDetailsVM VTeam { get; set; }
        public CompetingTeamDetailsVM HTeam { get; set; }
        public List<OfficialVM> Officials { get; set; }

        public NbaGameDetailsVM(NbaGameDetails g)
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
            VTeam = (g.VTeam != null) ? new CompetingTeamDetailsVM(g.VTeam) : null;
            HTeam = (g.HTeam != null) ? new CompetingTeamDetailsVM(g.HTeam) : null;
        }
    }
}
