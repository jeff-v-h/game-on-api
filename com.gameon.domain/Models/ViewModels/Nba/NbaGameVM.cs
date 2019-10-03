using com.gameon.data.ThirdPartyApis.Models.Nba;

namespace com.gameon.domain.Models.ViewModels.Nba
{
    public class NbaGameVM : NbaGameBaseVM
    {
        public CompetingTeamVM VTeam { get; set; }
        public CompetingTeamVM HTeam { get; set; }

        public NbaGameVM(NbaGame g)
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
