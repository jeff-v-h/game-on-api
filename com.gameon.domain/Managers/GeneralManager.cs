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
        private readonly INbaManager _nbaManager;
        private readonly IFootballManager _footballManager;
        private readonly ITennisManager _tennisManager;
        private readonly IEsportsManager _esportsManager;

        public GeneralManager(INbaManager nbaManager, IFootballManager footballManager,
            ITennisManager tennisManager, IEsportsManager esportsManager)
        {
            _nbaManager = nbaManager;
            _footballManager = footballManager;
            _tennisManager = tennisManager;
            _esportsManager = esportsManager;
        }

        public async Task<SortedEventsVM> GetEventsAsync()
        {
            //var now = DateTime.UtcNow;
            var input = "\"2019-04-23T12:00:00.000Z\"";
            var now = DateTime.ParseExact(input, "'\"'yyyy-MM-dd'T'HH:mm:ss.fff'Z\"'", null);

            // Get the matches for each sport
            var nbaTask = GetNbaEventsAsync(now);
            var eplTask = GetFootballEventsAsync("epl", now);
            var europaLeagueTask = GetFootballEventsAsync("europaLeague", now);
            var championsLeagueTask = GetFootballEventsAsync("championsleague", now);
            //var tennisTask = GetTennisEventsAsync(now);
            var esportsTask = GetEsportsEventsAsync(now);

            //var allTasks = new List<Task<SortedEventsVM>> { nbaTask, eplTask, europaLeagueTask, championsLeagueTask, esportsTask };
            var allTasks = new List<Task<SortedEventsVM>> { nbaTask };

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

                if (finishedTask == nbaTask)
                {
                    Console.WriteLine("nbaTask is ready");
                }
                else if (finishedTask == eplTask)
                {
                    Console.WriteLine("eplTask is ready");
                }
                else if (finishedTask == europaLeagueTask)
                {
                    Console.WriteLine("europaLeagueTask is ready");
                }
                else if (finishedTask == championsLeagueTask)
                {
                    Console.WriteLine("championsLeagueTask is ready");
                }
                //else if (finishedTask == tennisTask)
                //{
                //    Console.WriteLine("tennisTask is ready");
                //}
                else if (finishedTask == esportsTask)
                {
                    Console.WriteLine("esportsTask is ready");
                }
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
            var getGames = _nbaManager.GetNbaSchedule();
            var time12HrsAgo = now.AddHours(-12);
            var timeIn24Hrs = now.AddHours(24);
            SortedEventsVM events = new SortedEventsVM
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
            var getGames = _footballManager.GetSchedule(league);
            SortedEventsVM events = new SortedEventsVM();
            var time12HrsAgo = now.AddHours(-12);
            var timeIn24Hrs = now.AddHours(24);

            var games = await getGames;

            // Loop through all games and get the recently completed, live and upcoming games
            // Pass into and create an EventVM object for if it matches above criteria
            for (int i = 0; i < games.Count; i++)
            {
                var game = games[i];

                if (game.Status == "Match Finished")
                {
                    // Keep nested to ensure game does not go through check for live or upcoming
                    if (game.EventDate.HasValue)
                    {
                        // Only add to recently completed if it finished less than 12 hours ago (end time > the time 12 hrs ago)
                        var value = DateTime.Compare(game.EventDate.Value, time12HrsAgo);
                        if (value > 0) events.RecentlyCompleted.Add(new EventVM(game));
                    }
                }
                else if (game.Status == "Not Started")
                {
                    if (game.EventDate.HasValue)
                    {
                        var startTime = game.EventDate.Value;
                        if (DateTime.Compare(startTime, timeIn24Hrs) < 0)
                            events.Upcoming.Add(new EventVM(game));
                    }
                }
                else
                {
                    events.Live.Add(new EventVM(game));
                }
            }

            return events;
        }
        
        private async Task<SortedEventsVM> GetTennisEventsAsync(DateTime now)
        {
            var getMatches = _tennisManager.GetMatches();
            SortedEventsVM events = new SortedEventsVM();
            var time12HrsAgo = now.AddHours(-12);
            var timeIn24Hrs = now.AddHours(24);

            var matches = await getMatches;

            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];

                if (match.Status == "closed")
                {
                    // Keep nested to ensure game does not go through check for live or upcoming
                    if (match.Scheduled.HasValue)
                    {
                        // Only add to recently completed if it finished less than 12 hours ago (end time > the time 12 hrs ago)
                        var value = DateTime.Compare(match.Scheduled.Value, time12HrsAgo);
                        if (value > 0) events.RecentlyCompleted.Add(new EventVM(match));
                    }
                }
                else if (match.Status == "not_started")
                {
                    if (match.Scheduled.HasValue)
                    {
                        var startTime = match.Scheduled.Value;
                        if (DateTime.Compare(startTime, timeIn24Hrs) < 0)
                            events.Upcoming.Add(new EventVM(match));
                    }
                }
                else
                {
                    events.Live.Add(new EventVM(match));
                }
            }

            return events;
        }

        private async Task<SortedEventsVM> GetEsportsEventsAsync(DateTime now)
        {
            var getMatches = _esportsManager.GetMatches();
            SortedEventsVM events = new SortedEventsVM();
            var time12HrsAgo = now.AddHours(-12);
            var timeIn24Hrs = now.AddHours(24);

            var matches = await getMatches;

            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];

                if (match.Status == "finished")
                {
                    // Keep nested to ensure game does not go through check for live or upcoming
                    if (match.EndAt.HasValue)
                    {
                        // Only add to recently completed if it finished less than 12 hours ago (end time > the time 12 hrs ago)
                        var value = DateTime.Compare(match.EndAt.Value, time12HrsAgo);
                        if (value > 0) events.RecentlyCompleted.Add(new EventVM(match));
                    }
                }
                else if (match.Status == "not_started")
                {
                    if (match.BeginAt.HasValue)
                    {
                        var startTime = match.BeginAt.Value;
                        if (DateTime.Compare(startTime, timeIn24Hrs) < 0)
                            events.Upcoming.Add(new EventVM(match));
                    }
                }
                else
                {
                    events.Live.Add(new EventVM(match));
                }
            }

            return events;
        }
    }
}
