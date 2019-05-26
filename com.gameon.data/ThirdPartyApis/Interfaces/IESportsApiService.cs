using com.gameon.data.ThirdPartyApis.Models.Esports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface IESportsApiService
    {
        Task<List<Tournament>> GetTournaments(string game);
        Task<List<Team>> GetTeams(string game);
        Task<List<Series>> GetSeries(string game);
        Task<List<Match>> GetMatches(string game);
    }
}
