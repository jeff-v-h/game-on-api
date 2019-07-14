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
        public TennisManager(ITennisApiService service)
        {
            _service = service;
        }

        public async Task<List<TournamentVM>> GetTournaments()
        {
            var tournaments = await _service.GetTournaments();

            var tournamentVMs = new List<TournamentVM>();
            foreach (var t in tournaments) tournamentVMs.Add(new TournamentVM(t));

            return tournamentVMs;
        }

        public async Task<InfoApiVM> GetTournamentInfo(string id)
        {
            var info = await _service.GetTournamentInfo(id);

            return new InfoApiVM(info);
        }

        public async Task<List<SportEventVM>> GetTournamentSchedule(string id)
        {
            var schedule = await _service.GetTournamentSchedule(id);

            var scheduleVMs = new List<SportEventVM>();
            foreach (var s in schedule) scheduleVMs.Add(new SportEventVM(s));

            return scheduleVMs;
        }

        public async Task<List<SportEventVM>> GetMatchesUpcoming()
        {
            // Get matches for today and tomorrow
            var today = DateTime.UtcNow;
            var tomorrow = today.AddDays(1);
            var matchesToday = await _service.GetDaySchedule(today);
            var matchesTomorrow = await _service.GetDaySchedule(tomorrow);

            // Only return the matches that have not started and are at a professional tournament
            string[] atpLevels = { "atp_250", "atp_500", "atp_1000", "grand_slam", "wta_premier", "wta_international" };
            var upcoming = matchesToday.FindAll(m => m.Status == "not_started" && Array.IndexOf(atpLevels, m.Tournament.Category.Level) > -1);
            upcoming.AddRange(matchesTomorrow);

            var scheduleVMs = new List<SportEventVM>();
            foreach (var u in upcoming) scheduleVMs.Add(new SportEventVM(u));

            return scheduleVMs;
        }

        public async Task<List<SportEventVM>> GetMatchesLive()
        {
            // Get matches for today and tomorrow
            var today = DateTime.UtcNow;
            var matchesToday = await _service.GetDaySchedule(today);

            // Only return the matches that have not started and are at a professional tournament
            string[] atpLevels = { "atp_250", "atp_500", "atp_1000", "grand_slam", "wta_premier", "wta_international" };
            var matches = matchesToday.FindAll(m => m.Status == "live" && Array.IndexOf(atpLevels, m.Tournament.Category.Level) > -1);

            var scheduleVMs = new List<SportEventVM>();
            foreach (var m in matches) scheduleVMs.Add(new SportEventVM(m));

            return scheduleVMs;
        }

        public async Task<List<SportEventVM>> GetDaySchedule(string dateString)
        {
            DateTime date;
            List<SportEvent> schedule;
            if (DateTime.TryParse(dateString, out date)) schedule = await _service.GetDaySchedule(date);
            else schedule = await _service.GetDaySchedule();

            var scheduleVMs = new List<SportEventVM>();
            foreach (var s in schedule) scheduleVMs.Add(new SportEventVM(s));

            return scheduleVMs;
        }

        //public async Task<List<>> GetLiveMatches()
        //{
        //    var schedule = await _service.GetLiveSchedule();

        //    var scheduleVMs = new List<>();
        //    foreach (var s in schedule) scheduleVMs.Add(new (s));

        //    return scheduleVMs;
        //}

        public async Task<List<AssociationRankingsVM>> GetPlayerRankings()
        {
            var rankings = await _service.GetPlayerRankings();

            var rankingsVM = new List<AssociationRankingsVM>();
            foreach (var r in rankings) rankingsVM.Add(new AssociationRankingsVM(r));

            return rankingsVM;
        }
    }
}
