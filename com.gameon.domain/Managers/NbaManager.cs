using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Nba;
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

        public async Task<List<TeamVM>> GetNbaTeams()
        {
            var teams = await _service.GetNbaTeams();

            var teamVMs = new List<TeamVM>();
            foreach (var t in teams) teamVMs.Add(new TeamVM(t));

            return teamVMs;
        }
    }
}
