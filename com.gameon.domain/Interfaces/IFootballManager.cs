using com.gameon.domain.ViewModels.Football;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IFootballManager
    {
        Task<List<FixtureVM>> GetEplSchedule();
        Task<List<TeamVM>> GetEplTeams();
        Task<List<FixtureVM>> GetChampionsLeagueSchedule();
        Task<List<TeamVM>> GetChampionsLeagueTeams();
        Task<List<FixtureVM>> GetEuropaLeagueSchedule();
        Task<List<TeamVM>> GetEuropaLeagueTeams();
    }
}
