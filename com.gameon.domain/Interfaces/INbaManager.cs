using com.gameon.domain.ViewModels.Nba;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface INbaManager
    {
        Task<List<GameVM>> GetNbaSchedule();
        Task<List<NbaTeamVM>> GetNbaTeams();
        Task<List<GameVM>> GetNbaGamesUpcoming();
        Task<List<GameVM>> GetNbaLiveGames();
    }
}
