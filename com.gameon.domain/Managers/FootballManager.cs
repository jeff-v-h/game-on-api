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

        public async Task<List<FixtureVM>> GetEplSchedule()
        {
            var fixtures = await _service.GetEplSchedule();

            var fixtureVMs = new List<FixtureVM>();
            foreach (var f in fixtures) fixtureVMs.Add(new FixtureVM(f));

            return fixtureVMs;
        }

        public async Task<List<TeamVM>> GetEplTeams()
        {
            var teams = await _service.GetEplTeams();

            var teamVMs = new List<TeamVM>();
            foreach (var t in teams) teamVMs.Add(new TeamVM(t));

            return teamVMs;
        }

        public async Task<List<FixtureVM>> GetChampionsLeagueSchedule()
        {
            var fixtures = await _service.GetChampionsLeagueSchedule();

            var fixtureVMs = new List<FixtureVM>();
            foreach (var f in fixtures) fixtureVMs.Add(new FixtureVM(f));

            return fixtureVMs;
        }

        public async Task<List<TeamVM>> GetChampionsLeagueTeams()
        {
            var teams = await _service.GetChampionsLeagueTeams();

            var teamVMs = new List<TeamVM>();
            foreach (var t in teams) teamVMs.Add(new TeamVM(t));

            return teamVMs;
        }

        public async Task<List<FixtureVM>> GetEuropaLeagueSchedule()
        {
            var fixtures = await _service.GetEuropaLeagueSchedule();

            var fixtureVMs = new List<FixtureVM>();
            foreach (var f in fixtures) fixtureVMs.Add(new FixtureVM(f));

            return fixtureVMs;
        }

        public async Task<List<TeamVM>> GetEuropaLeagueTeams()
        {
            var teams = await _service.GetEuropaLeagueTeams();

            var teamVMs = new List<TeamVM>();
            foreach (var t in teams) teamVMs.Add(new TeamVM(t));

            return teamVMs;
        }
    }
}
