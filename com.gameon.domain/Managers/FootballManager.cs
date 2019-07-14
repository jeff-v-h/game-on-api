using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models.Football;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Football;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Managers
{
    public class FootballManager : IFootballManager
    {
        private readonly IFootballApiService _service;
        public FootballManager(IFootballApiService service)
        {
            _service = service;
        }

        public async Task<List<FixtureVM>> GetSchedule(string league)
        {
            var fixtures = await _service.GetSchedule(league);

            var fixtureVMs = new List<FixtureVM>();
            foreach (var f in fixtures) fixtureVMs.Add(new FixtureVM(f));

            return fixtureVMs;
        }

        public async Task<List<FixtureVM>> GetLiveGames(string league)
        {
            var fixtures = await _service.GetLiveGames(league);

            var fixtureVMs = new List<FixtureVM>();
            foreach (var f in fixtures) fixtureVMs.Add(new FixtureVM(f));

            return fixtureVMs;
        }

        /**
         * Get games within next 24 hours. Does not return games that have started. (GetLiveGames() does that)
         */
        public async Task<List<FixtureVM>> GetGamesUpcoming(string league)
        {
            var fixtures = await _service.GetSchedule(league);

            // Filter games to find those that will happen within the next 24 hours
            var now = DateTime.UtcNow.Ticks;
            var ticks24HrsFromNow = now + TimeSpan.TicksPerDay;
            var gamesNext24 = fixtures.FindAll(f => f.EventDate.HasValue
                && f.EventDate.Value.Ticks > now
                && f.EventDate.Value.Ticks < ticks24HrsFromNow);

            var fixtureVMs = new List<FixtureVM>();
            foreach (var game in gamesNext24) fixtureVMs.Add(new FixtureVM(game));

            return fixtureVMs;
        }

        public async Task<List<TeamVM>> GetTeams(string league)
        {
            var teams = await _service.GetTeams(league);

            var teamVMs = new List<TeamVM>();
            foreach (var t in teams) teamVMs.Add(new TeamVM(t));

            return teamVMs;
        }
    }
}
