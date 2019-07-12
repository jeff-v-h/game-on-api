using com.gameon.domain.ViewModels.Esports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Interfaces
{
    public interface IESportsManager
    {
        Task<List<ESportsTournamentVM>> GetTournaments(string game = null, string timeFrame = null);
        Task<List<ESportsTeamVM>> GetTeams(string game);
        Task<List<SeriesVM>> GetSeries(string game);
        Task<List<MatchVM>> GetMatches(string game = null, int? tournamentId = null, string timeFrame = null);
    }
}
