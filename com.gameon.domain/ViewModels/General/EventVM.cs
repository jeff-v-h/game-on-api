using com.gameon.domain.ViewModels.Nba;
using System;
using System.Collections.Generic;

namespace com.gameon.domain.ViewModels.General
{
    public class EventVM
    {
        public string Id;
        public DateTime? StartTime;
        public DateTime? EndTime;
        public string Name;
        public string Sport;
        public string LeagueOrTournament;
        public List<CompetitorVM> Competitors;

        public EventVM(GameVM g)
        {
            Id = "nba" + g.GameId;
            StartTime = g.StartTimeUTC ?? null;
            EndTime = g.EndTimeUTC ?? null;
            Name = g.HTeam.ShortName + "v" + g.VTeam.ShortName;
            Sport = "Basketball";
            LeagueOrTournament = "NBA";
            Competitors = MapNbaCompetitors(g.HTeam, g.VTeam);
        }

        private List<CompetitorVM> MapNbaCompetitors(CompetingTeamVM hTeam, CompetingTeamVM vTeam)
        {
            return new List<CompetitorVM>
            {
                new CompetitorVM(hTeam),
                new CompetitorVM(vTeam)
            };
        }
    }
}
