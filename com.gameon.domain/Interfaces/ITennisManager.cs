using com.gameon.domain.Models.ViewModels.Tennis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface ITennisManager
    {
        Task<List<TournamentVM>> GetTournamentsAsync();
        Task<InfoApiVM> GetTournamentInfoAsync(string id);
        Task<List<SportEventVM>> GetTournamentScheduleAsync(string id);
        Task<List<SportEventVM>> GetDayScheduleAsync(string dateString = null);
        Task<List<SportEventVM>> GetMatchesAsync();
        Task<List<SportEventVM>> GetMatchesUpcomingAsync();
        Task<List<SportEventVM>> GetMatchesLiveAsync();
        Task<List<AssociationRankingsVM>> GetPlayerRankingsAsync();
    }
}
