using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface ITennisApiService
    {
        Task<List<Tournament>> GetTournaments();
        Task<InfoApi> GetTournamentInfo(string id);
        Task<List<SportEvent>> GetTournamentSchedule(string id);
    }
}
