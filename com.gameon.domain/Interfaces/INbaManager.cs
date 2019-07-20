using com.gameon.domain.ViewModels.Nba;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface INbaManager
    {
        Task<List<GameVM>> GetNbaScheduleAsync();
        Task<List<NbaTeamVM>> GetNbaTeamsAsync();
        Task<List<GameVM>> GetNbaGamesUpcomingAsync();
        Task<List<GameVM>> GetNbaLiveGamesAsync();
    }
}
