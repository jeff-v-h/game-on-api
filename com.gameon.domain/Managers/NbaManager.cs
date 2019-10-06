using AutoMapper;
using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models.Nba;
using com.gameon.domain.Interfaces;
using com.gameon.domain.Models.ViewModels.Nba;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Managers
{
    public class NbaManager : INbaManager
    {
        private readonly INbaApiService _service;
        private readonly IMapper _mapper;
        public NbaManager(INbaApiService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<NbaGameVM>> GetNbaScheduleAsync()
        {
            var games = await _service.GetNbaScheduleAsync();

            var gameVMs = new List<NbaGameVM>();
            foreach (var g in games)
                gameVMs.Add(_mapper.Map<NbaGameVM>(g));

            return gameVMs;
        }

        public async Task<List<NbaGameVM>> GetNbaLiveGamesAsync()
        {
            var games = await _service.GetNbaLiveGamesAsync();

            var gameVMs = new List<NbaGameVM>();
            foreach (var g in games)
                gameVMs.Add(_mapper.Map<NbaGameVM>(g));

            return gameVMs;
        }

        /**
         * Get games within next 24 hours. Does not return games that have started. (Another function does that)
         */
        public async Task<List<NbaGameVM>> GetNbaGamesUpcomingAsync()
        {
            Task<List<NbaGame>> getSchedule = _service.GetNbaScheduleAsync();

            // Filter games to find those that will happen within the next 24 hours
            var today = DateTime.UtcNow.Ticks;
            var in24Hours = today + TimeSpan.TicksPerDay;

            var games = await getSchedule;
            var gamesNext24 = games.FindAll(g => g.StartTimeUTC.HasValue 
                && g.StartTimeUTC.Value.Ticks > today
                && g.StartTimeUTC.Value.Ticks < in24Hours);

            var gameVMs = new List<NbaGameVM>();
            foreach (var game in gamesNext24)
                gameVMs.Add(_mapper.Map<NbaGameVM>(game));

            return gameVMs;
        }


        // Get details for a specific game. Returns null if not found
        public async Task<NbaGameDetailsVM> GetNbaGameDetailsAsync(string gameId)
        {
            var game = await _service.GetNbaGameDetailsAsync(gameId);

            return (game != null) ? _mapper.Map<NbaGameDetailsVM>(game) : null;
        }

        public async Task<List<NbaTeamVM>> GetNbaTeamsAsync()
        {
            var teams = await _service.GetNbaTeamsAsync();

            var teamVMs = new List<NbaTeamVM>();
            foreach (var t in teams)
                teamVMs.Add(_mapper.Map<NbaTeamVM>(t));

            return teamVMs;
        }
    }
}
