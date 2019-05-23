using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Esports;
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

        public async Task<ESportsTournamentsVM> GetDotaTournaments()
        {
            var tournaments = await _service.GetDotaTournaments();

            //var tournamentVMs = new List<ESportsTournamentVM>();
            //foreach (var t in tournaments) tournamentVMs.Add(new ESportsTournamentVM(t));

            return new ESportsTournamentsVM(tournaments);
        }

        public async Task<ESportsTournamentsVM> GetLolTournaments()
        {
            var tournaments = await _service.GetLolTournaments();

            return new ESportsTournamentsVM(tournaments);
        }

        public async Task<ESportsTournamentsVM> GetOverwatchTournaments()
        {
            var tournaments = await _service.GetOverwatchTournaments();

            return new ESportsTournamentsVM(tournaments);
        }

        public async Task<ESportsTournamentsVM> GetCsgoTournaments()
        {
            var tournaments = await _service.GetCsgoTournaments();

            return new ESportsTournamentsVM(tournaments);
        }
    }
}
