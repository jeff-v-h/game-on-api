using com.gameon.data.ThirdPartyApis.Interfaces;
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
            //var input = "\"2019-01-06T00:00:00.000Z\"";
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
            var getMatchesTodayTask = _tennisService.GetDayScheduleAsync(today);
            var getMatchesTomorrowTask = _tennisService.GetDayScheduleAsync(tomorrow);

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

            // Await the async tasks
            var matchesToday = await getMatchesTodayTask;
            var matchesTomorrow = await getMatchesTomorrowTask;

            // Only return the matches that are at a professional tournament
            var matches = matchesToday.FindAll(m => Array.IndexOf(atpLevels, m.Tournament.Category.Level) > -1);
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
    }
}
