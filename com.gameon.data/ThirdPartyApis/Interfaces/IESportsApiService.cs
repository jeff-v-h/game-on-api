using com.gameon.data.ThirdPartyApis.Models.Esports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.data.ThirdPartyApis.Interfaces
{
    public interface IEsportsApiService
    {
        Task<List<EsportsTournament>> GetTournamentsAsync(string game = null, string timeFrame = null, string seriesId = null);
        Task<List<EsportsTeam>> GetTeamsAsync(string game);
        Task<List<Series>> GetSeriesAsync(string game, List<DateTime> range = null);
        Task<List<Match>> GetMatchesAsync(string game = null, string timeFrame = null);
        Task<List<Match>> GetTournamentMatchesAsync(string game, int tournamentId, string timeFrame = null);
    }
}
