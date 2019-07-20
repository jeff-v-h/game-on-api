using com.gameon.data.ThirdPartyApis.Models.Football;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface IFootballApiService
    {
        Task<List<Fixture>> GetScheduleAsync(string league);
        Task<List<Fixture>> GetLiveGamesAsync(string league);
        Task<List<FootballTeam>> GetTeamsAsync(string league);
    }
}
