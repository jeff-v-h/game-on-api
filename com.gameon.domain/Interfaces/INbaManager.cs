using com.gameon.domain.ViewModels.Nba;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface INbaManager
    {
        Task<List<GameVM>> GetNbaSchedule();
        Task<List<NbaTeamVM>> GetNbaTeams();
        Task<List<GameVM>> GetNbaGamesNext24Hrs();
        Task<List<GameVM>> GetNbaLiveGames();
    }
}
