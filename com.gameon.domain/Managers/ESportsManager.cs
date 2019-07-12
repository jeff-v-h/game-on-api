using com.gameon.data.ThirdPartyApis.Interfaces;
using com.gameon.data.ThirdPartyApis.Models.Esports;
using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Esports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace com.gameon.domain.Managers
{
    public class ESportsManager : IESportsManager
    {
        private readonly IESportsApiService _service;
        public ESportsManager(IESportsApiService service)
        {
            _service = service;
        }

        public async Task<List<ESportsTournamentVM>> GetTournaments(string game = null, string timeFrame = null)
        {
            List<Tournament> tournaments = await _service.GetTournaments(game, timeFrame);

            var tournamentVMs = new List<ESportsTournamentVM>();
            foreach (var t in tournaments) tournamentVMs.Add(new ESportsTournamentVM(t));

            return tournamentVMs;
        }

        public async Task<List<ESportsTeamVM>> GetTeams(string game)
        {
            var teams = await _service.GetTeams(game);

            var teamVMs = new List<ESportsTeamVM>();
            foreach (var t in teams) teamVMs.Add(new ESportsTeamVM(t));

            return teamVMs;
        }

        public async Task<List<SeriesVM>> GetSeries(string game)
        {
            var series = await _service.GetSeries(game);

            var seriesVM = new List<SeriesVM>();
            // Due to api sort by descending starts with null dates, must not return the beginning few objects
            var indexFirst = series.FindIndex(x => !(x.BeginAt == null && x.EndAt == null));
            for (int i = indexFirst; i < series.Count; i++)
                seriesVM.Add(new SeriesVM(series[i]));

            return seriesVM;
        }

        public async Task<List<MatchVM>> GetMatches(string game = null, int? tournamentId = null, string timeFrame = null)
        {
            // Determine whether to get most recent matches for the game or for a specific tournament
            List<Match> matches;

            if (game == null) matches = await _service.GetMatches(timeFrame: timeFrame);
            else if (tournamentId.HasValue) matches = await _service.GetTournamentMatches(game, tournamentId.Value, timeFrame);
            else matches = await _service.GetMatches(game, timeFrame: timeFrame);

            // Convert to view model
            var matchVM = new List<MatchVM>();
            foreach (var t in matches) matchVM.Add(new MatchVM(t));

            return matchVM;
        }
    }
}
