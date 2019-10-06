using com.gameon.data.ThirdPartyApis.Models.Esports;
using com.gameon.data.ThirdPartyApis.Models.Football;
using com.gameon.data.ThirdPartyApis.Models.Nba;
using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System;
using System.Collections.Generic;

namespace com.gameon.domain.Models.ViewModels.General
{
    public class EventVM
    {
        public string Id;
        public DateTime? StartTime;
        public DateTime? EndTime;
        // "Completed", "Live" ("Ongoing" if isTournament), "Upcoming", "Postponed", "Canceled", ""
        public string Status;
        public string Name;
        public string Sport;
        public string LeagueOrTournament;
        public string Selector; // Used to select for dropdown
        public bool IsTournament;
        public List<CompetitorVM> Competitors;

        // NBA
        public EventVM(NbaGame g)
        {
            Id = "basketball-nba-" + g.GameId;
            StartTime = g.StartTimeUTC ?? null;
            EndTime = g.EndTimeUTC ?? null;
            Status = (g.StatusGame == "Finished") ? "Completed"
                : (g.StatusGame == "Scheduled") ? "Upcoming"
                : (g.StatusGame == "Live") ? "Live"
                : "";
            Name = g.HTeam.ShortName + " v " + g.VTeam.ShortName;
            Sport = "Basketball";
            LeagueOrTournament = "NBA";
            Selector = "nba";
            Competitors = MapNbaCompetitors(g.HTeam, g.VTeam);
        }

        // Football
        public EventVM(Fixture g)
        {
            Id = "football-" + g.LeagueId + "-" + g.FixtureId;
            StartTime = g.EventDate ?? null;
            EndTime = null;
            // FT = full time, TBD = to be defined, PST = postponed, NS = not started, FH/SH = first/second half
            Status = (g.StatusShort == "FT") ? "Completed"
                : (g.StatusShort == "TBD" || g.StatusShort == "NS") ? "Upcoming"
                : (g.StatusShort == "FH" || g.StatusShort == "SH") ? "Live" // TODO is there one for extra time or penalties?
                : (g.StatusShort == "PST") ? "Postponed"
                : "";
            Name = g.HomeTeam.TeamName + " v " + g.AwayTeam.TeamName;
            Sport = "Football";
            LeagueOrTournament = (g.LeagueId == 2) ? "EPL" 
                : (g.LeagueId == 132) ? "Champions League"
                : (g.LeagueId == 137) ? "Europa League"
                : null;
            Selector = (g.LeagueId == 2) ? "epl"
                : (g.LeagueId == 132) ? "champions league"
                : (g.LeagueId == 137) ? "europa league"
                : "football";
            Competitors = MapFootballCompetitors(g.HomeTeam, g.AwayTeam, g.GoalsHomeTeam, g.GoalsAwayTeam);
        }

        // Tennis map match
        public EventVM(SportEvent e)
        {
            Id = "tennis-match-" + e.Id;
            StartTime = e.Scheduled ?? null;
            EndTime = null;
            Status = (e.Status == "closed" || e.Status == "ended") ? "Completed"
                : (e.Status == "not_started" || e.Status == "match_about_to_start") ? "Upcoming"
                : (e.Status == "live") ? "Live"
                : (e.Status == "interrupted" || e.Status == "suspended") ? "Postponed"
                : (e.Status == "canceled" || e.Status == "abandoned") ? "Canceled"
                : "";
            Name = GetTennisEventName(e.Competitors);
            Sport = "Tennis";
            LeagueOrTournament = e.Tournament.Name;
            Selector = "tennis";
            Competitors = MapTennisCompetitors(e.Competitors); // TODO get scores and pass into
        }

        // Tennis map tournament
        public EventVM(TennisTournament e)
        {
            Id = "tennis-tournament-" + e.Id;
            StartTime = MapTennisDateString(e.CurrentSeason?.StartDate);
            EndTime = MapTennisDateString(e.CurrentSeason?.EndDate);
            Status = GetTennisTournamentStatus(e.CurrentSeason);
            Name = e.Name;
            Sport = "Tennis";
            LeagueOrTournament = e.Name;
            Selector = "tennis";
            IsTournament = true;
        }

        // Esports Match
        public EventVM(Match e)
        {
            Id = "esports-" + e.VideoGame.Id + "-match-" + e.Id;
            StartTime = e?.BeginAt;
            EndTime = e?.EndAt;
            Status = (e.Status == "finished") ? "Completed"
                : (e.Status == "not_started") ? "Upcoming"
                : (e.Status == "running") ? "Live"
                : (e.Status == "canceled") ? "Canceled"
                : "";
            Name = e.Name;
            Sport = e.VideoGame.Name;
            LeagueOrTournament = GetEsportsTournamentName(e);
            Selector = GetEsportsSelector(e.VideoGame.Name);
            Competitors = MapEsportsCompetitors(e.Opponents, e.Results);
        }

        // Esports Tournament
        public EventVM(EsportsTournament e)
        {
            Id = "esports-" + e.VideoGame.Id + "-tournament-" + e.Id;
            StartTime = e?.BeginAt;
            EndTime = e?.EndAt;
            Status = GetEsportsTournamentStatus(e);
            Name = GetEsportsTournamentName(e);
            Sport = e.VideoGame.Name;
            LeagueOrTournament = GetEsportsTournamentName(e);
            Selector = GetEsportsSelector(e.VideoGame.Name);
            IsTournament = true;
            Competitors = MapEsportsCompetitors(e.Teams);
        }

        private DateTime? MapTennisDateString(string date)
        {
            var dateParts = date.Split("-");

            if (dateParts.Length == 3 &&
                Int32.TryParse(dateParts[0], out int year) &&
                Int32.TryParse(dateParts[1], out int month) &&
                Int32.TryParse(dateParts[2], out int day))
            {
                return new DateTime(year, month, day);
            }

            return null;
        }

        private string GetTennisTournamentStatus(Season currentSeason)
        {
            if (currentSeason != null)
            {
                // date is in format "2019-05-31"
                var dateParts = currentSeason.StartDate?.Split("-");
                if (dateParts != null && dateParts.Length == 3 &&
                    Int32.TryParse(dateParts[0], out int year) &&
                    Int32.TryParse(dateParts[1], out int month) &&
                    Int32.TryParse(dateParts[2], out int day))
                {
                    var now = DateTime.UtcNow;
                    var startDateTime = new DateTime(year, month, day);

                    if (now.Date < startDateTime.Date)
                        return "Upcoming";
                    else
                    {
                        var endDateParts = currentSeason.EndDate?.Split("-");
                        if (endDateParts != null && endDateParts.Length == 3 &&
                            Int32.TryParse(endDateParts[0], out int endYear) &&
                            Int32.TryParse(endDateParts[1], out int endMonth) &&
                            Int32.TryParse(endDateParts[2], out int endDay))
                        {
                            var endDateTime = new DateTime(endYear, endMonth, endDay);

                            if (now.Date > endDateTime.Date)
                                return "Completed";
                            else
                                return "Ongoing";
                        }
                        // Is start date but no end date, so assume ongoing
                        else
                            return "Ongoing";
                    }
                }
            }
            return "";
        }

        private string GetEsportsTournamentStatus(EsportsTournament tournament)
        {
            if (tournament != null)
            {
                var now = DateTime.UtcNow;

                if (tournament.BeginAt.HasValue && now.Date < tournament.BeginAt.Value.Date)
                    return "Upcoming";
                else
                {
                    if (tournament.EndAt.HasValue && now.Date > tournament.EndAt.Value.Date)
                        return "Completed";
                    else
                        return "Ongoing";
                }
            }
           
            return "";
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

        private string GetEsportsTournamentName(EsportsTournament e)
        {
            string name = "";
            if (!string.IsNullOrEmpty(e.League.Name)) name += e.League.Name;
            if (!string.IsNullOrEmpty(e.Series.Name))
            {
                if (!string.IsNullOrEmpty(name)) name += " ";
                name += e.Series.Name;
            }
            if (!string.IsNullOrEmpty(e.Name))
            {
                if (!string.IsNullOrEmpty(name)) name += " ";
                name += e.Name;
            }

            return name;
        }

        private string GetEsportsSelector(string name)
        {
            switch (name)
            {
                case "Dota 2":
                    return "dota";
                case "LoL":
                    return "lol";
                case "CS:GO":
                    return "csgo";
                case "Overwatch":
                    return "overwatch";
                default:
                    return "esport";
            }
        }

        private List<CompetitorVM> MapEsportsCompetitors(List<EsportsTeamBase> teams)
        {
            var competitors = new List<CompetitorVM>();

            foreach (var team in teams) competitors.Add(new CompetitorVM(team, null));

            return competitors;
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
