using com.gameon.domain.ViewModels.Tennis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface ITennisManager
    {
        Task<List<TournamentVM>> GetTournamentsAsyncAsync();
        Task<InfoApiVM> GetTournamentInfoAsync(string id);
        Task<List<SportEventVM>> GetTournamentScheduleAsync(string id);
        Task<List<SportEventVM>> GetDayScheduleAsync(string dateString = null);
        Task<List<SportEventVM>> GetMatchesAsyncAsync();
        Task<List<SportEventVM>> GetMatchesAsyncUpcomingAsync();
        Task<List<SportEventVM>> GetMatchesAsyncLiveAsync();
        Task<List<AssociationRankingsVM>> GetPlayerRankingsAsync();
    }
}
