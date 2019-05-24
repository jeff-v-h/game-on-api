using com.gameon.domain.ViewModels.Esports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IESportsManager
    {
        Task<List<ESportsTournamentVM>> GetDotaTournaments();
        Task<List<ESportsTournamentVM>> GetLolTournaments();
        Task<List<ESportsTournamentVM>> GetOverwatchTournaments();
        Task<List<ESportsTournamentVM>> GetCsgoTournaments();
    }
}
