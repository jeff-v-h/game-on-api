using com.gameon.domain.Models.ViewModels.Football;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IFootballManager
    {
        Task<List<FixtureVM>> GetScheduleAsync(string league);
        Task<List<FixtureVM>> GetLiveGamesAsync(string league);
        Task<List<FixtureVM>> GetGamesUpcomingAsync(string league);
        Task<List<TeamVM>> GetTeamsAsync(string league);
    }
}
