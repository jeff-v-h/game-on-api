using com.gameon.data.ThirdPartyApis.Models.Football;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface IFootballApiService
    {
        Task<List<Fixture>> GetSchedule(string league);
        Task<List<Fixture>> GetLiveGames(string league);
        Task<List<Team>> GetTeams(string league);
    }
}
