using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models.Tennis;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Tennis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Managers
{
    public class TennisManager : ITennisManager
    {
        private readonly ITennisApiService _service;
        string[] _atpLevels = { "atp_250", "atp_500", "atp_1000", "grand_slam", "wta_premier", "wta_international" };

        public TennisManager(ITennisApiService service)
        {
            _service = service;
        }

        public async Task<List<TournamentVM>> GetTournamentsAsync()
        {
            var tournaments = await _service.GetTournamentsAsync();

            var tournamentVMs = new List<TournamentVM>();
            foreach (var t in tournaments) tournamentVMs.Add(new TournamentVM(t));

            return tournamentVMs;
        }

        public async Task<InfoApiVM> GetTournamentInfoAsync(string id)
        {
            var info = await _service.GetTournamentInfoAsync(id);

            return new InfoApiVM(info);
        }

        public async Task<List<SportEventVM>> GetTournamentScheduleAsync(string id)
        {
            var schedule = await _service.GetTournamentScheduleAsync(id);

            var scheduleVMs = new List<SportEventVM>();
            foreach (var s in schedule) scheduleVMs.Add(new SportEventVM(s));

            return scheduleVMs;
        }

        // This will get matches for today and tomorrow
        public async Task<List<SportEventVM>> GetMatchesAsyncAsync()
        {
            // Get matches for today and tomorrow
            var today = DateTime.UtcNow;
            var getMatchesTodayTask = _service.GetDayScheduleAsync(today);
            var tomorrow = today.AddDays(1);
            var getMatchesTomorrowTask = _service.GetDayScheduleAsync(tomorrow);

            var matchesToday = await getMatchesTodayTask;
            var matchesTomorrow = await getMatchesTomorrowTask;

            // Only return the matches that have not started and are at a professional tournament
            var matches = matchesToday.FindAll(m => Array.IndexOf(_atpLevels, m.Tournament.Category.Level) > -1);
            var matchesTomorrowSorted = matchesTomorrow.FindAll(m => Array.IndexOf(_atpLevels, m.Tournament.Category.Level) > -1);
            matches.AddRange(matchesTomorrowSorted);

            var matchVMs = new List<SportEventVM>();
            foreach (var m in matches) matchVMs.Add(new SportEventVM(m));

            return matchVMs;
        }

        public async Task<List<SportEventVM>> GetMatchesAsyncUpcomingAsync()
        {
            // Get matches for today and tomorrow
            var today = DateTime.UtcNow;
            var tomorrow = today.AddDays(1);
            var matchesToday = await _service.GetDayScheduleAsync(today);
            var matchesTomorrow = await _service.GetDayScheduleAsync(tomorrow);

            // Only return the matches that have not started and are at a professional tournament
            var upcoming = matchesToday.FindAll(m => m.Status == "not_started" && Array.IndexOf(_atpLevels, m.Tournament.Category.Level) > -1);
            upcoming.AddRange(matchesTomorrow);

            var scheduleVMs = new List<SportEventVM>();
            foreach (var u in upcoming) scheduleVMs.Add(new SportEventVM(u));

            return scheduleVMs;
        }

        public async Task<List<SportEventVM>> GetMatchesAsyncLiveAsync()
        {
            // Get matches for today and tomorrow
            var today = DateTime.UtcNow;
            var matchesToday = await _service.GetDayScheduleAsync(today);

            // Only return the matches that have not started and are at a professional tournament
            var matches = matchesToday.FindAll(m => m.Status == "live" && Array.IndexOf(_atpLevels, m.Tournament.Category.Level) > -1);

            var scheduleVMs = new List<SportEventVM>();
            foreach (var m in matches) scheduleVMs.Add(new SportEventVM(m));

            return scheduleVMs;
        }

        public async Task<List<SportEventVM>> GetDayScheduleAsync(string dateString = null)
        {
            DateTime date;
            List<SportEvent> schedule;
            if (DateTime.TryParse(dateString, out date)) schedule = await _service.GetDayScheduleAsync(date);
            else schedule = await _service.GetDayScheduleAsync();

            var scheduleVMs = new List<SportEventVM>();
            foreach (var s in schedule) scheduleVMs.Add(new SportEventVM(s));

            return scheduleVMs;
        }

        public async Task<List<AssociationRankingsVM>> GetPlayerRankingsAsync()
        {
            var rankings = await _service.GetPlayerRankingsAsync();

            var rankingsVM = new List<AssociationRankingsVM>();
            foreach (var r in rankings) rankingsVM.Add(new AssociationRankingsVM(r));

            return rankingsVM;
        }
    }
}
