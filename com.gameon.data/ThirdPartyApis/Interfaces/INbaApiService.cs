using com.gameon.data.ThirdPartyApis.Models.Nba;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface INbaApiService
    {
        Task<List<NbaGame>> GetNbaScheduleAsync();
        Task<List<NbaGame>> GetNbaGamesAsync(DateTime? datetime = null);
        Task<List<NbaTeam>> GetNbaTeamsAsync();
        Task<NbaGameDetails> GetNbaGameDetailsAsync(string gameId);
        Task<List<NbaGame>> GetNbaLiveGamesAsync();
    }
}
