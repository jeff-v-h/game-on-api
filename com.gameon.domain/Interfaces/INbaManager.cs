using com.gameon.domain.ViewModels.Nba;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface INbaManager
    {
        Task<List<NbaGameVM>> GetNbaScheduleAsync();
        Task<List<NbaTeamVM>> GetNbaTeamsAsync();
        Task<List<NbaGameVM>> GetNbaGamesUpcomingAsync();
        Task<List<NbaGameVM>> GetNbaLiveGamesAsync();
        Task<NbaGameDetailsVM> GetNbaGameDetailsAsync(string gameId);
    }
}
