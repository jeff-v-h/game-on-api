using com.gameon.data.ThirdPartyApis.Models.Tennis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface ITennisApiService
    {
        Task<List<Tournament>> GetTournaments();
        Task<InfoApi> GetTournamentInfo(string id);
        Task<List<SportEvent>> GetTournamentSchedule(string id);
        Task<List<SportEvent>> GetDailySchedule(DateTime? datetime = null);
        Task<List<AssociationRankings>> GetPlayerRankings();
    }
}
