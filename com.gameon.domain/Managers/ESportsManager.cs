using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models.Esports;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Esports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Managers
{
    public class EsportsManager : IEsportsManager
    {
        private readonly IEsportsApiService _service;
        public EsportsManager(IEsportsApiService service)
        {
            _service = service;
        }

        public async Task<List<EsportsTournamentVM>> GetTournamentsAsync(string game = null, string timeFrame = null)
        {
            List<Tournament> tournaments = await _service.GetTournamentsAsync(game, timeFrame);

            var tournamentVMs = new List<EsportsTournamentVM>();
            foreach (var t in tournaments) tournamentVMs.Add(new EsportsTournamentVM(t));

            return tournamentVMs;
        }

        public async Task<List<EsportsTeamVM>> GetTeamsAsync(string game)
        {
            var teams = await _service.GetTeamsAsync(game);

            var teamVMs = new List<EsportsTeamVM>();
            foreach (var t in teams) teamVMs.Add(new EsportsTeamVM(t));

            return teamVMs;
        }

        public async Task<List<SeriesVM>> GetSeriesAsync(string game)
        {
            var series = await _service.GetSeriesAsync(game);

            var seriesVM = new List<SeriesVM>();
            // Due to api sort by descending starts with null dates, must not return the beginning few objects
            var indexFirst = series.FindIndex(x => !(x.BeginAt == null && x.EndAt == null));
            for (int i = indexFirst; i < series.Count; i++)
                seriesVM.Add(new SeriesVM(series[i]));

            return seriesVM;
        }

        // Get matches for specified game or all, game and tournament and either with a specified timeframe (eg. "upcoming")
        public async Task<List<MatchVM>> GetMatchesAsync(string game = null, int? tournamentId = null, string timeFrame = null)
        {
            // Determine whether to get most recent matches for the game or for a specific tournament
            List<Match> matches;

            if (game == null) matches = await _service.GetMatchesAsync(timeFrame: timeFrame);
            else if (tournamentId.HasValue) matches = await _service.GetTournamentMatchesAsync(game, tournamentId.Value, timeFrame);
            else matches = await _service.GetMatchesAsync(game, timeFrame: timeFrame);

            // Convert to view model
            var matchVM = new List<MatchVM>();
            foreach (var t in matches) matchVM.Add(new MatchVM(t));

            return matchVM;
        }
    }
}
