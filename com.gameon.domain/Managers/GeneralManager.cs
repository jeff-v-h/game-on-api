using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models.Tennis;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.gameon.domain.Managers
{
    public class GeneralManager : IGeneralManager
    {
        private readonly INbaApiService _nbaService;
        private readonly IFootballApiService _footballService;
        private readonly ITennisApiService _tennisService;
        private readonly IEsportsApiService _esportsService;

        public GeneralManager(INbaApiService nbaService, IFootballApiService footballService,
            ITennisApiService tennisService, IEsportsApiService esportsService)
        {
            _nbaService = nbaService;
            _footballService = footballService;
            _tennisService = tennisService;
            _esportsService = esportsService;
        }

        public async Task<SortedEventsVM> GetEventsAsync()
        {
            var now = DateTime.UtcNow;
            //var input = "\"2019-02-12T00:00:00.000Z\"";
            //var now = DateTime.ParseExact(input, "'\"'yyyy-MM-dd'T'HH:mm:ss.fff'Z\"'", null);

            // Get the matches for each sport
            var nbaTask = GetNbaEventsAsync(now);
            var eplTask = GetFootballEventsAsync("epl", now);
            var europaLeagueTask = GetFootballEventsAsync("europaLeague", now);
            var championsLeagueTask = GetFootballEventsAsync("championsleague", now);
            //var tennisTask = GetTennisEventsAsync(now);
            var esportsTask = GetEsportsEventsAsync(now);

            var allTasks = new List<Task<SortedEventsVM>> { nbaTask, eplTask, europaLeagueTask, championsLeagueTask, esportsTask };

            var liveEvents = new List<EventVM>();
            var upcomingEvents = new List<EventVM>();
            var completedEvents = new List<EventVM>();
            
            // Each time a task is finished, add the events into their respective lists
            while (allTasks.Any())
            {
                Task<SortedEventsVM> finishedTask = await Task.WhenAny(allTasks);
                allTasks.Remove(finishedTask);

                SortedEventsVM games = await finishedTask;
                if (games.Live != null) liveEvents.AddRange(games.Live);
                if (games.Upcoming != null) upcomingEvents.AddRange(games.Upcoming);
                if (games.RecentlyCompleted != null) completedEvents.AddRange(games.RecentlyCompleted);
            }

            // Once all tasks are finished, order them by date
            var allEventsSorted = new SortedEventsVM
            {
                Live = liveEvents.OrderBy(x => x.StartTime).ToList(),
                Upcoming = upcomingEvents.OrderBy(x => x.StartTime).ToList(),
                RecentlyCompleted = completedEvents.OrderByDescending(x => x.StartTime).ToList()
            };

            return allEventsSorted;
        }

        private async Task<SortedEventsVM> GetNbaEventsAsync(DateTime now)
        {
            var getGames = _nbaService.GetNbaScheduleAsync();
            var time12HrsAgo = now.AddHours(-12);
            var timeIn24Hrs = now.AddHours(24);
            var events = new SortedEventsVM
            {
                Live = new List<EventVM>(),
                RecentlyCompleted = new List<EventVM>(),
                Upcoming = new List<EventVM>()
            };

            var nbaGames = await getGames;

            // Loop through all games and get the recently completed, live and upcoming games
            // Pass into and create an EventVM object for if it matches above criteria
            for (int i = 0; i < nbaGames.Count; i++)
            {
                var game = nbaGames[i];

                if (game.StartTimeUTC.HasValue)
                {
                    var startTime = game.StartTimeUTC.Value;

                    //if (game.StatusGame == "Scheduled")
                    if (now < startTime)
                    {
                        var isUpcoming = startTime < timeIn24Hrs;
                        if (isUpcoming) events.Upcoming.Add(new EventVM(game));
                    }
                    //else if (game.StatusGame == "Finished")
                    else if (game.EndTimeUTC.HasValue)
                    {
                        var endTime = game.EndTimeUTC.Value;
                        var isRecentlyCompleted = endTime > time12HrsAgo;
                        // Keep nested to ensure game does not go through check for live or upcoming
                        // Only add to recently completed if it finished less than 12 hours ago (end time > the time 12 hrs ago)
                        if (isRecentlyCompleted) events.RecentlyCompleted.Add(new EventVM(game));
                    }
                    //else if (now >= startTime) // only works when not using fake date
                    else if (now >= startTime && game.StatusGame != "Scheduled" && game.StatusGame != "Finished" )
                    {
                        events.Live.Add(new EventVM(game));
                    }
                }
            }

            return events;
        }

        private async Task<SortedEventsVM> GetFootballEventsAsync(string league, DateTime now)
        {
            var getMatchesTask = _footballService.GetScheduleAsync(league);
            var time14HrsAgo = now.AddHours(-14);
            var timeIn24Hrs = now.AddHours(24);
            var events = new SortedEventsVM
            {
                Live = new List<EventVM>(),
                RecentlyCompleted = new List<EventVM>(),
                Upcoming = new List<EventVM>()
            };

            var matches = await getMatchesTask;

            // Loop through all games and get the recently completed, live and upcoming games
            // Pass into and create an EventVM object for if it matches above criteria
            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];

                if (match.EventDate.HasValue)
                {
                    var startTime = match.EventDate.Value;

                    //if (game.StatusGame == "Not Started")
                    if (now < startTime)
                    {
                        var isUpcoming = startTime < timeIn24Hrs;
                        if (isUpcoming) events.Upcoming.Add(new EventVM(match));
                    }
                    else if (match.Status == "Match Finished")
                    {
                        var isRecentlyCompleted = startTime > time14HrsAgo;
                        if (isRecentlyCompleted) events.RecentlyCompleted.Add(new EventVM(match));
                    }
                    //else if (now >= startTime) // only works when not using fake date
                    else if (now >= startTime && match.Status != "Not Started" && match.Status != "Match Finished")
                    {
                        events.Live.Add(new EventVM(match));
                    }
                }
            }

            return events;
        }
        
        private async Task<SortedEventsVM> GetTennisEventsAsync(DateTime now)
        {
            // Get matches for today and tomorrow
            var today = DateTime.UtcNow;
            var tomorrow = today.AddDays(1);
            var yesterday = today.AddDays(-1);
            var getMatchesTodayTask = _tennisService.GetDayScheduleAsync(today);
            var getMatchesTomorrowTask = _tennisService.GetDayScheduleAsync(tomorrow);

            // Get events for day before if before midday to have more for reently completed
            var timeMidday = new DateTime(today.Year, today.Month, today.Day, 12, 0, 0);
            var isBeforeMidday = today < timeMidday;
            var getMatchesYesterdayTask = (isBeforeMidday) ? _tennisService.GetDayScheduleAsync() : null;

            // Create variables
            string[] atpLevels = { "atp_250", "atp_500", "atp_1000", "grand_slam", "wta_premier", "wta_international" };
            var time14HrsAgo = now.AddHours(-14); // use 14 instead of 12 since no endtime
            var timeIn24Hrs = now.AddHours(24);
            var events = new SortedEventsVM
            {
                Live = new List<EventVM>(),
                RecentlyCompleted = new List<EventVM>(),
                Upcoming = new List<EventVM>()
            };
            var matches = new List<SportEvent>();

            // Await the async tasks
            var matchesYesterday = (isBeforeMidday) ? await getMatchesYesterdayTask : null;
            var matchesToday = await getMatchesTodayTask;
            var matchesTomorrow = await getMatchesTomorrowTask;

            // Only return the matches that are at a professional tournament
            if (isBeforeMidday)
            {
                var matchesYesterdaySorted = matchesYesterday.FindAll(m => Array.IndexOf(atpLevels, m.Tournament.Category.Level) > -1);
                matches.AddRange(matchesYesterdaySorted);
            }
            var matchesTodaySorted = matchesToday.FindAll(m => Array.IndexOf(atpLevels, m.Tournament.Category.Level) > -1);
            matches.AddRange(matchesTodaySorted);
            var matchesTomorrowSorted = matchesTomorrow.FindAll(m => Array.IndexOf(atpLevels, m.Tournament.Category.Level) > -1);
            matches.AddRange(matchesTomorrowSorted);

            // Sort events to get live, upcoming and recently completed
            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];

                if (match.Scheduled.HasValue)
                {
                    var startTime = match.Scheduled.Value;

                    //if (game.StatusGame == "not_started")
                    if (now < startTime)
                    {
                        var isUpcoming = startTime < timeIn24Hrs;
                        if (isUpcoming) events.Upcoming.Add(new EventVM(match));
                    }
                    else if (match.Status == "closed")
                    {
                        var isRecentlyCompleted = startTime > time14HrsAgo;
                        if (isRecentlyCompleted) events.RecentlyCompleted.Add(new EventVM(match));
                    }
                    //else if (now >= startTime) // only works when not using fake date
                    else if (now >= startTime && match.Status != "not_started" && match.Status != "closed")
                    {
                        events.Live.Add(new EventVM(match));
                    }
                }
            }

            return events;
        }

        private async Task<SortedEventsVM> GetEsportsEventsAsync(DateTime now)
        {
            var getMatchesTask = _esportsService.GetMatchesAsync();
            var time12HrsAgo = now.AddHours(-12);
            var timeIn24Hrs = now.AddHours(24);
            var events = new SortedEventsVM
            {
                Live = new List<EventVM>(),
                RecentlyCompleted = new List<EventVM>(),
                Upcoming = new List<EventVM>()
            };

            var matches = await getMatchesTask;

            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];

                if (match.BeginAt.HasValue)
                {
                    var startTime = match.BeginAt.Value;

                    //if (game.StatusGame == "not_started")
                    if (now < startTime)
                    {
                        var isUpcoming = startTime < timeIn24Hrs;
                        if (isUpcoming) events.Upcoming.Add(new EventVM(match));
                    }
                    //else if (match.Status == "finished")
                    else if (match.EndAt.HasValue)
                    {
                        var endTime = match.EndAt.Value;
                        var isRecentlyCompleted = endTime > time12HrsAgo;
                        if (isRecentlyCompleted) events.RecentlyCompleted.Add(new EventVM(match));
                    }
                    //else if (now >= startTime) // only works when not using fake date
                    else if (now >= startTime && match.Status != "not_started" && match.Status != "finished")
                    {
                        events.Live.Add(new EventVM(match));
                    }
                }
            }

            return events;
        }

        /**
         * startDateString in format: "yyyy-mm-dd"
         */
        public async Task<SortedWeekEventsVM> GetSortedWeekEventsAsync(string weekStartDateString = null)
        {
            DateTime weekStartDate = (weekStartDateString == null) ? DateTime.UtcNow
                : GetDateFromReverseStringFormat(weekStartDateString);

            //var input = "\"2019-04-20T00:00:00.000Z\"";
            //var weekStartDate = DateTime.ParseExact(input, "'\"'yyyy-MM-dd'T'HH:mm:ss.fff'Z\"'", null);

            // Get the matches for each sport
            var nbaTask = GetNbaWeekEventsAsync(weekStartDate);
            var eplTask = GetFootballWeekEventsAsync("epl", weekStartDate);
            var europaLeagueTask = GetFootballWeekEventsAsync("europaLeague", weekStartDate);
            var championsLeagueTask = GetFootballWeekEventsAsync("championsleague", weekStartDate);
            //var tennisTask = GetTennisWeekEventsAsync(weekStartDate);
            var esportsTask = GetEsportsWeekEventsAsync(weekStartDate);

            var allTasks = new List<Task<SortedWeekEventsVM>> { nbaTask, eplTask, europaLeagueTask, championsLeagueTask, esportsTask };

            var eventsToday = new List<EventVM>();
            var eventsTomorrow = new List<EventVM>();
            var eventsDay3 = new List<EventVM>();
            var eventsDay4 = new List<EventVM>();
            var eventsDay5 = new List<EventVM>();
            var eventsDay6 = new List<EventVM>();
            var eventsDay7 = new List<EventVM>();

            // Each time a task is finished, add the events into their respective lists
            while (allTasks.Any())
            {
                Task<SortedWeekEventsVM> finishedTask = await Task.WhenAny(allTasks);
                allTasks.Remove(finishedTask);

                SortedWeekEventsVM events = await finishedTask;
                if (events.Today != null) eventsToday.AddRange(events.Today);
                if (events.Tomorrow != null) eventsTomorrow.AddRange(events.Tomorrow);
                if (events.Day3 != null) eventsDay3.AddRange(events.Day3);
                if (events.Day4 != null) eventsDay4.AddRange(events.Day4);
                if (events.Day5 != null) eventsDay5.AddRange(events.Day5);
                if (events.Day6 != null) eventsDay6.AddRange(events.Day6);
                if (events.Day7 != null) eventsDay7.AddRange(events.Day7);
            }

            // Once all tasks are finished, order them by date
            var allEventsSorted = new SortedWeekEventsVM
            {
                Today = eventsToday.OrderBy(x => x.StartTime).ToList(),
                Tomorrow = eventsTomorrow.OrderBy(x => x.StartTime).ToList(),
                Day3 = eventsDay3.OrderBy(x => x.StartTime).ToList(),
                Day4 = eventsDay4.OrderBy(x => x.StartTime).ToList(),
                Day5 = eventsDay5.OrderBy(x => x.StartTime).ToList(),
                Day6 = eventsDay6.OrderBy(x => x.StartTime).ToList(),
                Day7 = eventsDay7.OrderBy(x => x.StartTime).ToList()
            };

            return allEventsSorted;
        }

        /**
         * dateString in format: "yyyy-mm-dd"
         */
        private DateTime GetDateFromReverseStringFormat(string dateString)
        {
            var dateParts = dateString.Split("-");

            if (dateParts.Length == 3)
            {
                if (Int32.TryParse(dateParts[0], out int year) &&
                    Int32.TryParse(dateParts[1], out int month) &&
                    Int32.TryParse(dateParts[2], out int day))
                {
                    return new DateTime(year, month, day);
                }
                else
                {
                    throw new Exception("Date provided needs to be numbers separated by a dash");
                }
            }
            else
            {
                throw new Exception("Date provided needs to be in format 'yyyy-mm-dd'");
            }
        }


        private async Task<SortedWeekEventsVM> GetNbaWeekEventsAsync(DateTime weekStartDate)
        {
            var getGames = _nbaService.GetNbaScheduleAsync();

            SortedWeekEventsVM events = GetEmptySortedWeekObject();
            var tomorrow = weekStartDate.AddDays(1);
            var day3 = weekStartDate.AddDays(2);
            var day4 = weekStartDate.AddDays(3);
            var day5 = weekStartDate.AddDays(4);
            var day6 = weekStartDate.AddDays(5);
            var day7 = weekStartDate.AddDays(6);

            var nbaGames = await getGames;

            // Loop through all games and get games within the next 7 days
            // Pass into and create an EventVM object if it matches this criteria
            for (int i = 0; i < nbaGames.Count; i++)
            {
                var game = nbaGames[i];

                if (game.StartTimeUTC.HasValue)
                {
                    var startDate = game.StartTimeUTC.Value.Date;

                    if (startDate == weekStartDate.Date) events.Today.Add(new EventVM(game));
                    else if (startDate == tomorrow.Date) events.Tomorrow.Add(new EventVM(game));
                    else if (startDate == day3.Date) events.Day3.Add(new EventVM(game));
                    else if (startDate == day4.Date) events.Day4.Add(new EventVM(game));
                    else if (startDate == day5.Date) events.Day5.Add(new EventVM(game));
                    else if (startDate == day6.Date) events.Day6.Add(new EventVM(game));
                    else if (startDate == day7.Date) events.Day7.Add(new EventVM(game));
                }
            }

            return events;
        }

        private async Task<SortedWeekEventsVM> GetFootballWeekEventsAsync(string league, DateTime weekStartDate)
        {
            var getMatchesTask = _footballService.GetScheduleAsync(league);

            SortedWeekEventsVM events = GetEmptySortedWeekObject();
            var tomorrow = weekStartDate.AddDays(1);
            var day3 = weekStartDate.AddDays(2);
            var day4 = weekStartDate.AddDays(3);
            var day5 = weekStartDate.AddDays(4);
            var day6 = weekStartDate.AddDays(5);
            var day7 = weekStartDate.AddDays(6);

            var matches = await getMatchesTask;

            // Loop through all games and get games within the next 7 days
            // Pass into and create an EventVM object if it matches this criteria
            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];

                if (match.EventDate.HasValue)
                {
                    var startDate = match.EventDate.Value.Date;

                    if (startDate == weekStartDate.Date) events.Today.Add(new EventVM(match));
                    else if (startDate == tomorrow.Date) events.Tomorrow.Add(new EventVM(match));
                    else if (startDate == day3.Date) events.Day3.Add(new EventVM(match));
                    else if (startDate == day4.Date) events.Day4.Add(new EventVM(match));
                    else if (startDate == day5.Date) events.Day5.Add(new EventVM(match));
                    else if (startDate == day6.Date) events.Day6.Add(new EventVM(match));
                    else if (startDate == day7.Date) events.Day7.Add(new EventVM(match));
                }
            }

            return events;
        }

        private async Task<SortedWeekEventsVM> GetTennisWeekEventsAsync(DateTime weekStartDate)
        {
            var getTournaments = _tennisService.GetTournamentsAsync();

            // Create variables
            SortedWeekEventsVM events = GetEmptySortedWeekObject();
            var tomorrow = weekStartDate.AddDays(1);
            var day3 = weekStartDate.AddDays(2);
            var day4 = weekStartDate.AddDays(3);
            var day5 = weekStartDate.AddDays(4);
            var day6 = weekStartDate.AddDays(5);
            var day7 = weekStartDate.AddDays(6);
            string[] atpLevels = { "atp_250", "atp_500", "atp_1000", "grand_slam", "wta_premier", "wta_international" };

            // Await the async task
            var tournaments = await getTournaments;

            for (int i = 0; i < tournaments.Count; i++)
            {
                var tournament = tournaments[i];
                bool isTopTournament = Array.IndexOf(atpLevels, tournament.Category?.Level) > -1;
                // date is in format "2019-05-31"
                var dateParts = tournament.CurrentSeason?.StartDate?.Split("-");

                if (isTopTournament && 
                    dateParts.Length == 3 && 
                    Int32.TryParse(dateParts[0], out int year) &&
                    Int32.TryParse(dateParts[1], out int month) &&
                    Int32.TryParse(dateParts[2], out int day))
                {
                    var startDateTime = new DateTime(year, month, day);
                    var startDate = startDateTime.Date;

                    //if (startDate == weekStartDate.Date) events.Today.Add(new EventVM(tournament));
                    //else if (startDate == tomorrow.Date) events.Tomorrow.Add(new EventVM(tournament));
                    //else if (startDate == day3.Date) events.Day3.Add(new EventVM(tournament));
                    //else if (startDate == day4.Date) events.Day4.Add(new EventVM(tournament));
                    //else if (startDate == day5.Date) events.Day5.Add(new EventVM(tournament));
                    //else if (startDate == day6.Date) events.Day6.Add(new EventVM(tournament));
                    //else if (startDate == day7.Date) events.Day7.Add(new EventVM(tournament));

                    bool isWithinWeek = false;
                    // Get matches for tournament if it any of it's days lie within the dates above.
                    if (startDate <= day7.Date)
                    {
                        var endDateParts = tournament.CurrentSeason?.EndDate?.Split("-");

                        if (endDateParts.Length == 3 &&
                            Int32.TryParse(dateParts[0], out int endDateYear) &&
                            Int32.TryParse(dateParts[1], out int endDateMonth) &&
                            Int32.TryParse(dateParts[2], out int endDateDay))
                        {
                            var endDateTime = new DateTime(endDateYear, endDateMonth, endDateDay);
                            var endDate = endDateTime.Date;
                            if (endDate >= weekStartDate.Date) isWithinWeek = true;
                        }
                        else if (startDate >= weekStartDate.Date) isWithinWeek = true;
                    }

                    if (isWithinWeek)
                    {
                        var tournamentsMatches = await _tennisService.GetTournamentScheduleAsync(tournament.Id);

                        for (int j = 0; j < tournamentsMatches.Count; j++)
                        {
                            var match = tournamentsMatches[j];

                            if (match.Scheduled.HasValue)
                            {
                                var matchStartDate = match.Scheduled.Value.Date;

                                if (matchStartDate == weekStartDate.Date) events.Today.Add(new EventVM(match));
                                else if (matchStartDate == tomorrow.Date) events.Tomorrow.Add(new EventVM(match));
                                else if (matchStartDate == day3.Date) events.Day3.Add(new EventVM(match));
                                else if (matchStartDate == day4.Date) events.Day4.Add(new EventVM(match));
                                else if (matchStartDate == day5.Date) events.Day5.Add(new EventVM(match));
                                else if (matchStartDate == day6.Date) events.Day6.Add(new EventVM(match));
                                else if (matchStartDate == day7.Date) events.Day7.Add(new EventVM(match));
                            }
                        }
                    }
                }
            }

            return events;
        }

        private async Task<SortedWeekEventsVM> GetEsportsWeekEventsAsync(DateTime weekStartDate)
        {
            var getTournaments = _esportsService.GetTournamentsAsync();

            // Create variables
            var events = GetEmptySortedWeekObject();
            var tomorrow = weekStartDate.AddDays(1);
            var day3 = weekStartDate.AddDays(2);
            var day4 = weekStartDate.AddDays(3);
            var day5 = weekStartDate.AddDays(4);
            var day6 = weekStartDate.AddDays(5);
            var day7 = weekStartDate.AddDays(6);

            // Await the async task
            var tournaments = await getTournaments;

            for (int i = 0; i < tournaments.Count; i++)
            {
                var tournament = tournaments[i];
                // date is in format "2019-05-31"

                if (tournament.BeginAt.HasValue)
                {
                    var startDate = tournament.BeginAt.Value.Date;

                    // Add the tournament if within a week of specified date
                    //if (startDate == weekStartDate.Date) events.Today.Add(new EventVM(tournament));
                    //else if (startDate == tomorrow.Date) events.Tomorrow.Add(new EventVM(tournament));
                    //else if (startDate == day3.Date) events.Day3.Add(new EventVM(tournament));
                    //else if (startDate == day4.Date) events.Day4.Add(new EventVM(tournament));
                    //else if (startDate == day5.Date) events.Day5.Add(new EventVM(tournament));
                    //else if (startDate == day6.Date) events.Day6.Add(new EventVM(tournament));
                    //else if (startDate == day7.Date) events.Day7.Add(new EventVM(tournament));

                    // Get matches for tournament if it any of it's days lie within the dates above.
                    bool isWithinWeek = false;

                    if (startDate <= day7.Date)
                    {
                        if (tournament.EndAt.HasValue)
                        {
                            var endDate = tournament.EndAt.Value.Date;
                            if (endDate >= weekStartDate.Date) isWithinWeek = true;
                        }
                        else if (startDate >= weekStartDate.Date) isWithinWeek = true;
                    }

                    if (isWithinWeek)
                    {
                        var esport = tournament.VideoGame.Name.Replace(" ", "");
                        var tournamentsMatches = await _esportsService.GetTournamentMatchesAsync(esport, tournament.Id);

                        for (int j = 0; j < tournamentsMatches.Count; j++)
                        {
                            var match = tournamentsMatches[j];

                            if (match.BeginAt.HasValue)
                            {
                                var matchStartDate = match.BeginAt.Value.Date;

                                if (matchStartDate == weekStartDate.Date) events.Today.Add(new EventVM(match));
                                else if (matchStartDate == tomorrow.Date) events.Tomorrow.Add(new EventVM(match));
                                else if (matchStartDate == day3.Date) events.Day3.Add(new EventVM(match));
                                else if (matchStartDate == day4.Date) events.Day4.Add(new EventVM(match));
                                else if (matchStartDate == day5.Date) events.Day5.Add(new EventVM(match));
                                else if (matchStartDate == day6.Date) events.Day6.Add(new EventVM(match));
                                else if (matchStartDate == day7.Date) events.Day7.Add(new EventVM(match));
                            }
                        }
                    }
                }
            }

            return events;
        }

        private SortedWeekEventsVM GetEmptySortedWeekObject()
        {
            return new SortedWeekEventsVM
            {
                Today = new List<EventVM>(),
                Tomorrow = new List<EventVM>(),
                Day3 = new List<EventVM>(),
                Day4 = new List<EventVM>(),
                Day5 = new List<EventVM>(),
                Day6 = new List<EventVM>(),
                Day7 = new List<EventVM>()
            };
        }
    }
}
