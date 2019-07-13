using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Football;
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

        public async Task<List<TeamVM>> GetTeams(string league)
        {
            var teams = await _service.GetTeams(league);

            var teamVMs = new List<TeamVM>();
            foreach (var t in teams) teamVMs.Add(new TeamVM(t));

            return teamVMs;
        }
    }
}
