using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Football;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Managers
{
    public class EplManager : IEplManager
    {
        private readonly IFootballApiService _service;
        public EplManager(IFootballApiService service)
        {
            _service = service;
        }

        public async Task<List<FixtureVM>> GetSchedule()
        {
            var fixtures = await _service.GetEplSchedule();

            var fixtureVMs = new List<FixtureVM>();
            foreach (var f in fixtures) fixtureVMs.Add(new FixtureVM(f));

            return fixtureVMs;
        }

        public async Task<List<TeamVM>> GetTeams()
        {
            var teams = await _service.GetEplTeams();

            var teamVMs = new List<TeamVM>();
            foreach (var t in teams) teamVMs.Add(new TeamVM(t));

            return teamVMs;
        }
    }
}
