using com.gameon.data.ThirdPartyApis.Models.Esports;
using com.gameon.data.ThirdPartyApis.Models.Football;
using com.gameon.data.ThirdPartyApis.Models.Nba;
using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System;
using System.Collections.Generic;
using System.Linq;

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

        // NBA
        public EventVM(NbaGame g)
        {
            Id = "basketball-nba-" + g.GameId;
            StartTime = g.StartTimeUTC ?? null;
            EndTime = g.EndTimeUTC ?? null;
            Name = g.HTeam.ShortName + " v " + g.VTeam.ShortName;
            Sport = "Basketball";
            LeagueOrTournament = "NBA";
            Competitors = MapNbaCompetitors(g.HTeam, g.VTeam);
        }

        // Football
        public EventVM(Fixture g)
        {
            Id = "football-" + g.LeagueId + "-" + g.FixtureId;
            StartTime = g.EventDate ?? null;
            EndTime = null;
            Name = g.HomeTeam.TeamName + " v " + g.AwayTeam.TeamName;
            Sport = "Football";
            LeagueOrTournament = (g.LeagueId == 2) ? "EPL" 
                : (g.LeagueId == 132) ? "Champions League"
                : (g.LeagueId == 137) ? "Europa League"
                : null;
            Competitors = MapFootballCompetitors(g.HomeTeam, g.AwayTeam, g.GoalsHomeTeam, g.GoalsAwayTeam);
        }

        // Tennis
        public EventVM(SportEvent e)
        {
            Id = "tennis-" + e.Id;
            StartTime = e.Scheduled ?? null;
            EndTime = null;
            Name = GetTennisEventName(e.Competitors);
            Sport = "Tennis";
            LeagueOrTournament = e.Tournament.Name;
            Competitors = MapTennisCompetitors(e.Competitors); // TODO get scores and pass into
        }

        // Esports
        public EventVM(Match e)
        {
            Id = "esports-" + e.VideoGame.Id + "-" + e.Id;
            StartTime = e?.BeginAt;
            EndTime = e?.EndAt;
            Name = e.Name;
            Sport = e.VideoGame.Name;
            LeagueOrTournament = GetEsportsTournamentName(e);
            Competitors = MapEsportsCompetitors(e.Opponents, e.Results);
        }

        private string GetEsportsTournamentName(Match e)
        {
            string name = "";
            if (!string.IsNullOrEmpty(e.League.Name)) name += e.League.Name;
            if (!string.IsNullOrEmpty(e.Series.Name))
            {
                if (!string.IsNullOrEmpty(name)) name += " ";
                name += e.Series.Name;
            }
            if (!string.IsNullOrEmpty(e.Tournament.Name))
            {
                if (!string.IsNullOrEmpty(name)) name += " ";
                name += e.Tournament.Name;
            }

            /** Using slug */
            //var nameParts = e.Tournament.Slug.Split("-");
            //string name = "";
            //foreach (var part in nameParts)
            //{
            //    name += part.First().ToString().ToUpper() + part.Substring(1) + " ";
            //}
            //// Remove the last space
            //name = name.Remove(name.Length - 1);

            return name;
        }

        private List<CompetitorVM> MapEsportsCompetitors(List<Competitor> opponents, List<Result> results)
        {
            var teams = new List<CompetitorVM>();
            foreach (var team in opponents)
            {
                var gamesWon = results.FindAll(x => x.TeamId == team.Opponent.Id).Count;
                teams.Add(new CompetitorVM(team.Opponent, gamesWon));
            }
            return teams;
        }

        private List<CompetitorVM> MapTennisCompetitors(List<TennisCompetitor> competitors)
        {
            var players = new List<CompetitorVM>();
            foreach (var player in competitors)
            {
                players.Add(new CompetitorVM(player));
            }
            return players;
        }

        private string GetTennisEventName(List<TennisCompetitor> competitors)
        {
            if (competitors?.Count > 0)
            {
                string name = competitors[0].Name;
                if (competitors[0].Seed != null) name += " [" + competitors[0].Seed + "]";
                name += " v ";
                name += (competitors.Count > 1) ? competitors[1].Name : "Tbd";
                if (competitors.Count > 1 && competitors[1].Seed != null) name += " [" + competitors[1].Seed + "]";

                return name;
            }
            else
            {
                return "Tbd v Tbd";
            }
        }

        private List<CompetitorVM> MapFootballCompetitors(FootballTeamBase homeTeam, FootballTeamBase awayTeam, int? goalsHome, int? goalsAway)
        {
            return new List<CompetitorVM>
            {
                new CompetitorVM(homeTeam, goalsHome),
                new CompetitorVM(awayTeam, goalsAway)
            };
        }

        private List<CompetitorVM> MapNbaCompetitors(CompetingTeam hTeam, CompetingTeam vTeam)
        {
            return new List<CompetitorVM>
            {
                new CompetitorVM(hTeam),
                new CompetitorVM(vTeam)
            };
        }
    }
}
