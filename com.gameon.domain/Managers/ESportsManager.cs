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

        public async Task<List<ESportsTournamentVM>> GetDotaTournaments()
        {
            var tournaments = await _service.GetDotaTournaments();

            var tournamentVMs = new List<ESportsTournamentVM>();
            foreach (var t in tournaments) tournamentVMs.Add(new ESportsTournamentVM(t));

            return tournamentVMs;
        }

        public async Task<List<ESportsTournamentVM>> GetLolTournaments()
        {
            var tournaments = await _service.GetLolTournaments();

            var tournamentVMs = new List<ESportsTournamentVM>();
            foreach (var t in tournaments) tournamentVMs.Add(new ESportsTournamentVM(t));

            return tournamentVMs;
        }

        public async Task<List<ESportsTournamentVM>> GetOverwatchTournaments()
        {
            var tournaments = await _service.GetOverwatchTournaments();

            var tournamentVMs = new List<ESportsTournamentVM>();
            foreach (var t in tournaments) tournamentVMs.Add(new ESportsTournamentVM(t));

            return tournamentVMs;
        }

        public async Task<List<ESportsTournamentVM>> GetCsgoTournaments()
        {
            var tournaments = await _service.GetCsgoTournaments();

            var tournamentVMs = new List<ESportsTournamentVM>();
            foreach (var t in tournaments) tournamentVMs.Add(new ESportsTournamentVM(t));

            return tournamentVMs;
        }
    }
}
