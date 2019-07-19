using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models.Nba;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Nba;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Managers
{
    public class NbaManager : INbaManager
    {
        private readonly INbaApiService _service;
        public NbaManager(INbaApiService service)
        {
            _service = service;
        }

        public async Task<List<GameVM>> GetNbaSchedule()
        {
            var games = await _service.GetNbaSchedule();

            var gameVMs = new List<GameVM>();
            foreach (var f in games) gameVMs.Add(new GameVM(f));

            return gameVMs;
        }

        public async Task<List<GameVM>> GetNbaLiveGames()
        {
            var games = await _service.GetNbaLiveGames();

            var gameVMs = new List<GameVM>();
            foreach (var f in games) gameVMs.Add(new GameVM(f));

            return gameVMs;
        }

        /**
         * Get games within next 24 hours. Does not return games that have started. (Another function does that)
         */
        public async Task<List<GameVM>> GetNbaGamesUpcoming()
        {
            Task<List<Game>> getSchedule = _service.GetNbaSchedule();

            // Filter games to find those that will happen within the next 24 hours
            var today = DateTime.UtcNow.Ticks;
            var in24Hours = today + TimeSpan.TicksPerDay;

            var games = await getSchedule;
            var gamesNext24 = games.FindAll(g => g.StartTimeUTC.HasValue 
                && g.StartTimeUTC.Value.Ticks > today
                && g.StartTimeUTC.Value.Ticks < in24Hours);

            var gameVMs = new List<GameVM>();
            foreach (var game in gamesNext24) gameVMs.Add(new GameVM(game));

            return gameVMs;
        }

        public async Task<List<NbaTeamVM>> GetNbaTeams()
        {
            var teams = await _service.GetNbaTeams();

            var teamVMs = new List<NbaTeamVM>();
            foreach (var t in teams) teamVMs.Add(new NbaTeamVM(t));

            return teamVMs;
        }
    }
}
