using com.gameon.data.ThirdPartyApis.Models.Esports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface IESportsApiService
    {
        Task<List<Tournament>> GetDotaTournaments();
        Task<List<Tournament>> GetLolTournaments();
        Task<List<Tournament>> GetOverwatchTournaments();
        Task<List<Tournament>> GetCsgoTournaments();
    }
}
