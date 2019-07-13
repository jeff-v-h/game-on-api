using com.gameon.domain.ViewModels.Football;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IFootballManager
    {
        Task<List<FixtureVM>> GetSchedule(string league);
        Task<List<FixtureVM>> GetLiveGames(string league);
        Task<List<FixtureVM>> GetGamesNext24Hrs(string league);
        Task<List<TeamVM>> GetTeams(string league);
    }
}
