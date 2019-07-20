using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface ITennisApiService
    {
        Task<List<Tournament>> GetTournamentsAsyncAsync();
        Task<InfoApi> GetTournamentInfoAsync(string id);
        Task<List<SportEvent>> GetTournamentScheduleAsync(string id);
        Task<List<SportEvent>> GetDayScheduleAsync(DateTime? datetime = null);
        Task<List<AssociationRankings>> GetPlayerRankingsAsync();
    }
}
