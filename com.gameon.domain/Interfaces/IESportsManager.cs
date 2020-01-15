using com.gameon.domain.Models.ViewModels.Esports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IEsportsManager
    {
        Task<List<EsportsTournamentVM>> GetTournamentsAsync(string game = null, string timeFrame = null, string seriesId = null);
        Task<List<EsportsTeamVM>> GetTeamsAsync(string game);
        Task<List<SeriesVM>> GetSeriesAsync(string game);
        Task<List<MatchVM>> GetMatchesAsync(string game = null, int? tournamentId = null, string timeFrame = null);
    }
}
