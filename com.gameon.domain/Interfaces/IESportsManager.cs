using com.gameon.domain.ViewModels.Esports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IEsportsManager
    {
        Task<List<EsportsTournamentVM>> GetTournamentsAsync(string game = null, string timeFrame = null);
        Task<List<EsportsTeamVM>> GetTeamsAsync(string game);
        Task<List<SeriesVM>> GetSeriesAsync(string game);
        Task<List<MatchVM>> GetMatchesAsync(string game = null, int? tournamentId = null, string timeFrame = null);
    }
}
