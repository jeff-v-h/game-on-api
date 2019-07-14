using com.gameon.domain.ViewModels.Tennis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface ITennisManager
    {
        Task<List<TournamentVM>> GetTournaments();
        Task<InfoApiVM> GetTournamentInfo(string id);
        Task<List<SportEventVM>> GetTournamentSchedule(string id);
        Task<List<SportEventVM>> GetDaySchedule(string dateString);
        Task<List<SportEventVM>> GetMatchesUpcoming();
        Task<List<SportEventVM>> GetMatchesLive();
        Task<List<AssociationRankingsVM>> GetPlayerRankings();
    }
}
