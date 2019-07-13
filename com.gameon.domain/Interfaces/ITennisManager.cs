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
        Task<List<SportEventVM>> GetDailySchedule(string dateString);
        Task<List<AssociationRankingsVM>> GetPlayerRankings();
    }
}
