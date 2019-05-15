using com.gameon.data.ThirdPartyApis.Models.Football;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface IFootballApiService
    {
        Task<List<Fixture>> GetEplSchedule();
        Task<List<Team>> GetEplTeams();
        Task<List<Fixture>> GetChampionsLeagueSchedule();
        Task<List<Team>> GetChampionsLeagueTeams();
        Task<List<Fixture>> GetEuropaLeagueSchedule();
        Task<List<Team>> GetEuropaLeagueTeams();
    }
}
