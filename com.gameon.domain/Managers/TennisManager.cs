﻿using com.gameon.data.ThirdPartyApis.Interfaces;
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

        public async Task<List<SportEventVM>> GetDailySchedule(string dateString)
        {
            DateTime date;
            List<SportEvent> schedule;
            if (DateTime.TryParse(dateString, out date)) schedule = await _service.GetDailySchedule(date);
            else schedule = await _service.GetDailySchedule();

            var scheduleVMs = new List<SportEventVM>();
            foreach (var s in schedule) scheduleVMs.Add(new SportEventVM(s));

            return scheduleVMs;
        }

        public async Task<List<AssociationRankingsVM>> GetPlayerRankings()
        {
            var rankings = await _service.GetPlayerRankings();

            var rankingsVM = new List<AssociationRankingsVM>();
            foreach (var r in rankings) rankingsVM.Add(new AssociationRankingsVM(r));

            return rankingsVM;
        }
    }
}
