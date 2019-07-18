using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.General;
using com.gameon.domain.ViewModels.Nba;
using System;
using System.Collections.Generic;
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

        public async Task<List<EventVM>> GetEvents()
        {
            // Get the matches for each sport
            var nbaTask = GetNbaEvents();
            var eplTask = GetEplEvents();
            var europaLeagueTask = GetEuropaLeagueEvents();
            var championsLeagueTask = GetChampionsLeagueEvents();
            var tennisTask = GetTennisEvents();
            var esportsTask = GetEsportsEvents();

            var tasks = await Task.WhenAll(nbaTask, eplTask, europaLeagueTask, championsLeagueTask, tennisTask, esportsTask);
            // Sort through each event

        }

        private async Task<SortedEventsVM> GetNbaEvents()
        {
            var nbaGames = await _nbaManager.GetNbaSchedule();

            SortedEventsVM events = new SortedEventsVM();

            var now = DateTime.UtcNow;
            var time12HrsAgo = now.AddHours(-12);
            var timeIn24Hrs = now.AddHours(24);

            // Loop through all games and get the recently completed, live and upcoming games
            // Pass into and create an EventVM object for if it matches above criteria
            for (int i = 0; i < nbaGames.Count; i++)
            {
                var game = nbaGames[i];

                if (game.StatusGame == "Finished")
                {
                    // Keep nested to ensure game does not go through check for live or upcoming
                    if (game.EndTimeUTC.HasValue)
                    {
                        // Only add to recently completed if it finished less than 12 hours ago (end time > the time 12 hrs ago)
                        var value = DateTime.Compare(game.EndTimeUTC.Value, time12HrsAgo);
                        if (value > 0) events.RecentlyCompleted.Add(new EventVM(game));
                    }
                }
                else if (game.StartTimeUTC.HasValue)
                {
                    var startTime = game.StartTimeUTC.Value;
                    if (DateTime.Compare(now, startTime) < 0)
                    {
                        if (DateTime.Compare(startTime, timeIn24Hrs) < 0)
                            events.Upcoming.Add(new EventVM(game));
                    }
                    else
                    {
                        events.Live.Add(new EventVM(game));
                    }
                }
            }

            return events;
        }

        private async Task<SortedEventsVM> GetEplEvents()
        {
            var nbaGames = await _nbaManager.GetNbaSchedule();

            SortedEventsVM events = new SortedEventsVM();

            var now = DateTime.UtcNow;
            var time12HrsAgo = now.AddHours(-12);
            var timeIn24Hrs = now.AddHours(24);

            // Loop through all games and get the recently completed, live and upcoming games
            // Pass into and create an EventVM object for if it matches above criteria
            for (int i = 0; i < nbaGames.Count; i++)
            {
                var game = nbaGames[i];

                if (game.StatusGame == "Finished")
                {
                    // Keep nested to ensure game does not go through check for live or upcoming
                    if (game.EndTimeUTC.HasValue)
                    {
                        // Only add to recently completed if it finished less than 12 hours ago (end time > the time 12 hrs ago)
                        var value = DateTime.Compare(game.EndTimeUTC.Value, time12HrsAgo);
                        if (value > 0) events.RecentlyCompleted.Add(new EventVM(game));
                    }
                }
                else if (game.StartTimeUTC.HasValue)
                {
                    var startTime = game.StartTimeUTC.Value;
                    if (DateTime.Compare(now, startTime) < 0)
                    {
                        if (DateTime.Compare(startTime, timeIn24Hrs) < 0)
                            events.Upcoming.Add(new EventVM(game));
                    }
                    else
                    {
                        events.Live.Add(new EventVM(game));
                    }
                }
            }

            return events;
        }
        

        private async Task<SortedEventsVM> GetEuropaLeagueEvents()
        {
            var nbaGames = await _nbaManager.GetNbaSchedule();

            SortedEventsVM events = new SortedEventsVM();

            var now = DateTime.UtcNow;
            var time12HrsAgo = now.AddHours(-12);
            var timeIn24Hrs = now.AddHours(24);

            // Loop through all games and get the recently completed, live and upcoming games
            // Pass into and create an EventVM object for if it matches above criteria
            for (int i = 0; i < nbaGames.Count; i++)
            {
                var game = nbaGames[i];

                if (game.StatusGame == "Finished")
                {
                    // Keep nested to ensure game does not go through check for live or upcoming
                    if (game.EndTimeUTC.HasValue)
                    {
                        // Only add to recently completed if it finished less than 12 hours ago (end time > the time 12 hrs ago)
                        var value = DateTime.Compare(game.EndTimeUTC.Value, time12HrsAgo);
                        if (value > 0) events.RecentlyCompleted.Add(new EventVM(game));
                    }
                }
                else if (game.StartTimeUTC.HasValue)
                {
                    var startTime = game.StartTimeUTC.Value;
                    if (DateTime.Compare(now, startTime) < 0)
                    {
                        if (DateTime.Compare(startTime, timeIn24Hrs) < 0)
                            events.Upcoming.Add(new EventVM(game));
                    }
                    else
                    {
                        events.Live.Add(new EventVM(game));
                    }
                }
            }

            return events;
        }
        

        private async Task<SortedEventsVM> GetChampionsLeagueEvents()
        {
            var nbaGames = await _nbaManager.GetNbaSchedule();

            SortedEventsVM events = new SortedEventsVM();

            var now = DateTime.UtcNow;
            var time12HrsAgo = now.AddHours(-12);
            var timeIn24Hrs = now.AddHours(24);

            // Loop through all games and get the recently completed, live and upcoming games
            // Pass into and create an EventVM object for if it matches above criteria
            for (int i = 0; i < nbaGames.Count; i++)
            {
                var game = nbaGames[i];

                if (game.StatusGame == "Finished")
                {
                    // Keep nested to ensure game does not go through check for live or upcoming
                    if (game.EndTimeUTC.HasValue)
                    {
                        // Only add to recently completed if it finished less than 12 hours ago (end time > the time 12 hrs ago)
                        var value = DateTime.Compare(game.EndTimeUTC.Value, time12HrsAgo);
                        if (value > 0) events.RecentlyCompleted.Add(new EventVM(game));
                    }
                }
                else if (game.StartTimeUTC.HasValue)
                {
                    var startTime = game.StartTimeUTC.Value;
                    if (DateTime.Compare(now, startTime) < 0)
                    {
                        if (DateTime.Compare(startTime, timeIn24Hrs) < 0)
                            events.Upcoming.Add(new EventVM(game));
                    }
                    else
                    {
                        events.Live.Add(new EventVM(game));
                    }
                }
            }

            return events;
        }

        private async Task<SortedEventsVM> GetTennisEvents()
        {
            var nbaGames = await _nbaManager.GetNbaSchedule();

            SortedEventsVM events = new SortedEventsVM();

            var now = DateTime.UtcNow;
            var time12HrsAgo = now.AddHours(-12);
            var timeIn24Hrs = now.AddHours(24);

            // Loop through all games and get the recently completed, live and upcoming games
            // Pass into and create an EventVM object for if it matches above criteria
            for (int i = 0; i < nbaGames.Count; i++)
            {
                var game = nbaGames[i];

                if (game.StatusGame == "Finished")
                {
                    // Keep nested to ensure game does not go through check for live or upcoming
                    if (game.EndTimeUTC.HasValue)
                    {
                        // Only add to recently completed if it finished less than 12 hours ago (end time > the time 12 hrs ago)
                        var value = DateTime.Compare(game.EndTimeUTC.Value, time12HrsAgo);
                        if (value > 0) events.RecentlyCompleted.Add(new EventVM(game));
                    }
                }
                else if (game.StartTimeUTC.HasValue)
                {
                    var startTime = game.StartTimeUTC.Value;
                    if (DateTime.Compare(now, startTime) < 0)
                    {
                        if (DateTime.Compare(startTime, timeIn24Hrs) < 0)
                            events.Upcoming.Add(new EventVM(game));
                    }
                    else
                    {
                        events.Live.Add(new EventVM(game));
                    }
                }
            }

            return events;
        }

        private async Task<SortedEventsVM> GetEsportsEvents()
        {
            var nbaGames = await _nbaManager.GetNbaSchedule();

            SortedEventsVM events = new SortedEventsVM();

            var now = DateTime.UtcNow;
            var time12HrsAgo = now.AddHours(-12);
            var timeIn24Hrs = now.AddHours(24);

            // Loop through all games and get the recently completed, live and upcoming games
            // Pass into and create an EventVM object for if it matches above criteria
            for (int i = 0; i < nbaGames.Count; i++)
            {
                var game = nbaGames[i];

                if (game.StatusGame == "Finished")
                {
                    // Keep nested to ensure game does not go through check for live or upcoming
                    if (game.EndTimeUTC.HasValue)
                    {
                        // Only add to recently completed if it finished less than 12 hours ago (end time > the time 12 hrs ago)
                        var value = DateTime.Compare(game.EndTimeUTC.Value, time12HrsAgo);
                        if (value > 0) events.RecentlyCompleted.Add(new EventVM(game));
                    }
                }
                else if (game.StartTimeUTC.HasValue)
                {
                    var startTime = game.StartTimeUTC.Value;
                    if (DateTime.Compare(now, startTime) < 0)
                    {
                        if (DateTime.Compare(startTime, timeIn24Hrs) < 0)
                            events.Upcoming.Add(new EventVM(game));
                    }
                    else
                    {
                        events.Live.Add(new EventVM(game));
                    }
                }
            }

            return events;
        }
    }
}
