using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Esports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Managers
{
    public class ESportsManager : IESportsManager
    {
        private readonly IESportsApiService _service;
        public ESportsManager(IESportsApiService service)
        {
            _service = service;
        }

        public async Task<List<ESportsTournamentVM>> GetTournaments(string game)
        {
            var tournaments = await _service.GetTournaments(game);

            var tournamentVMs = new List<ESportsTournamentVM>();
            foreach (var t in tournaments) tournamentVMs.Add(new ESportsTournamentVM(t));

            return tournamentVMs;
        }

        public async Task<List<ESportsTeamVM>> GetTeams(string game)
        {
            var teams = await _service.GetTeams(game);

            var teamVMs = new List<ESportsTeamVM>();
            foreach (var t in teams) teamVMs.Add(new ESportsTeamVM(t));

            return teamVMs;
        }

        public async Task<List<SeriesVM>> GetSeries(string game)
        {
            var series = await _service.GetSeries(game);

            var seriesVM = new List<SeriesVM>();
            foreach (var t in series) seriesVM.Add(new SeriesVM(t));

            return seriesVM;
        }

        public async Task<List<MatchVM>> GetMatches(string game)
        {
            var matches = await _service.GetMatches(game);

            var matchVM = new List<MatchVM>();
            foreach (var t in matches) matchVM.Add(new MatchVM(t));

            return matchVM;
        }
    }
}
