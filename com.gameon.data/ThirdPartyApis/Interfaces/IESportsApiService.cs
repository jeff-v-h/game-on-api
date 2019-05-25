using com.gameon.data.ThirdPartyApis.Models.Esports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface IESportsApiService
    {
        Task<List<Tournament>> GetDotaTournaments();
        Task<List<Team>> GetDotaTeams();
        Task<List<Tournament>> GetLolTournaments();
        Task<List<Team>> GetLolTeams();
        Task<List<Tournament>> GetOverwatchTournaments();
        Task<List<Team>> GetOverwatchTeams();
        Task<List<Tournament>> GetCsgoTournaments();
        Task<List<Team>> GetCsgoTeams();
    }
}
