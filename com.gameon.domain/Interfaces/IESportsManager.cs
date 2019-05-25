using com.gameon.domain.ViewModels.Esports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IESportsManager
    {
        Task<List<ESportsTournamentVM>> GetDotaTournaments();
        Task<List<ESportsTeamVM>> GetDotaTeams();
        Task<List<ESportsTournamentVM>> GetLolTournaments();
        Task<List<ESportsTeamVM>> GetLolTeams();
        Task<List<ESportsTournamentVM>> GetOverwatchTournaments();
        Task<List<ESportsTeamVM>> GetOverwatchTeams();
        Task<List<ESportsTournamentVM>> GetCsgoTournaments();
        Task<List<ESportsTeamVM>> GetCsgoTeams();
    }
}
