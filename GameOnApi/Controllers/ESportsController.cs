using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Esports;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOnApi.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    [ApiController]
    public class ESportsController : ControllerBase
    {
        private readonly IESportsManager _manager;

        public ESportsController(IESportsManager manager)
        {
            _manager = manager;
        }

        // GET api/esports/tournaments
        [HttpGet("esports/tournaments")]
        [ProducesResponseType(typeof(List<ESportsTournamentVM>), 200)]
        public async Task<IActionResult> GetESportsTournaments([FromQuery] string timeFrame)
        {
            List<ESportsTournamentVM> tournaments = await _manager.GetTournaments(timeFrame: timeFrame);

            return Ok(tournaments);
        }

        // GET api/esports/matches
        [HttpGet("esports/matches")]
        [ProducesResponseType(typeof(List<MatchVM>), 200)]
        public async Task<IActionResult> GetESportsMatches([FromQuery] string timeFrame)
        {
            // Get most recent matches from any tournament or for specific tournament
            List<MatchVM> matches = await _manager.GetMatches(timeFrame: timeFrame);

            return Ok(matches);
        }

        // GET api/dota/tournaments
        [HttpGet("dota/tournaments")]
        [ProducesResponseType(typeof(List<ESportsTournamentVM>), 200)]
        public async Task<IActionResult> GetDotaTournaments()
        {
            var tournaments = await _manager.GetTournaments("Dota");

            return Ok(tournaments);
        }

        // GET api/dota/teams
        [HttpGet("dota/teams")]
        [ProducesResponseType(typeof(List<ESportsTeamVM>), 200)]
        public async Task<IActionResult> GetDotaTeams()
        {
            var teams = await _manager.GetTeams("Dota");

            return Ok(teams);
        }

        // GET api/dota/series
        [HttpGet("dota/series")]
        [ProducesResponseType(typeof(List<SeriesVM>), 200)]
        public async Task<IActionResult> GetDotaSeries()
        {
            var series = await _manager.GetSeries("Dota");

            return Ok(series);
        }

        // GET api/dota/matches
        [HttpGet("dota/matches")]
        [ProducesResponseType(typeof(List<MatchVM>), 200)]
        public async Task<IActionResult> GetDotaMatches([FromQuery] int? tournamentId)
        {
            // Get most recent matches from any tournament or for specific tournament
            List<MatchVM> matches;
            if (tournamentId.HasValue) matches = await _manager.GetMatches("Dota", tournamentId);
            else matches = await _manager.GetMatches("Dota");

            return Ok(matches);
        }

        // GET api/lol/tournaments
        [HttpGet("lol/tournaments")]
        [ProducesResponseType(typeof(List<ESportsTournamentVM>), 200)]
        public async Task<IActionResult> GetLolTournaments()
        {
            var tournaments = await _manager.GetTournaments("LeagueOfLegends");

            return Ok(tournaments);
        }

        // GET api/lol/teams
        [HttpGet("lol/teams")]
        [ProducesResponseType(typeof(List<ESportsTeamVM>), 200)]
        public async Task<IActionResult> GetLolTeams()
        {
            var teams = await _manager.GetTeams("LeagueOfLegends");

            return Ok(teams);
        }

        // GET api/lol/series
        [HttpGet("lol/series")]
        [ProducesResponseType(typeof(List<SeriesVM>), 200)]
        public async Task<IActionResult> GetLolSeries()
        {
            var series = await _manager.GetSeries("LeagueOfLegends");

            return Ok(series);
        }

        // GET api/lol/matches
        [HttpGet("lol/matches")]
        [ProducesResponseType(typeof(List<MatchVM>), 200)]
        public async Task<IActionResult> GetLolMatches([FromQuery] int? tournamentId)
        {
            // Get most recent matches from any tournament or for specific tournament
            List<MatchVM> matches;
            if (tournamentId.HasValue) matches = await _manager.GetMatches("LeagueOfLegends", tournamentId);
            else matches = await _manager.GetMatches("LeagueOfLegends");

            return Ok(matches);
        }

        // GET api/overwatch/tournaments
        [HttpGet("overwatch/tournaments")]
        [ProducesResponseType(typeof(List<ESportsTournamentVM>), 200)]
        public async Task<IActionResult> GetOverwatchTournaments()
        {
            var tournaments = await _manager.GetTournaments("Overwatch");

            return Ok(tournaments);
        }

        // GET api/overwatch/teams
        [HttpGet("overwatch/teams")]
        [ProducesResponseType(typeof(List<ESportsTeamVM>), 200)]
        public async Task<IActionResult> GetOverwatchTeams()
        {
            var teams = await _manager.GetTeams("Overwatch");

            return Ok(teams);
        }

        // GET api/overwatch/series
        [HttpGet("overwatch/series")]
        [ProducesResponseType(typeof(List<SeriesVM>), 200)]
        public async Task<IActionResult> GetOverwatchSeries()
        {
            var series = await _manager.GetSeries("Overwatch");

            return Ok(series);
        }

        // GET api/overwatch/matches
        [HttpGet("overwatch/matches")]
        [ProducesResponseType(typeof(List<MatchVM>), 200)]
        public async Task<IActionResult> GetOverwatchMatches([FromQuery] int? tournamentId)
        {
            // Get most recent matches from any tournament or for specific tournament
            List<MatchVM> matches;
            if (tournamentId.HasValue) matches = await _manager.GetMatches("Overwatch", tournamentId);
            else matches = await _manager.GetMatches("Overwatch");

            return Ok(matches);
        }

        // GET api/csgo/tournaments
        [HttpGet("csgo/tournaments")]
        [ProducesResponseType(typeof(List<ESportsTournamentVM>), 200)]
        public async Task<IActionResult> GetCsgoTournaments()
        {
            var tournaments = await _manager.GetTournaments("CounterStrikeGlobalOffensive");

            return Ok(tournaments);
        }

        // GET api/csgo/teams
        [HttpGet("csgo/teams")]
        [ProducesResponseType(typeof(List<ESportsTeamVM>), 200)]
        public async Task<IActionResult> GetCsgoTeams()
        {
            var teams = await _manager.GetTeams("CounterStrikeGlobalOffensive");

            return Ok(teams);
        }

        // GET api/csgo/series
        [HttpGet("csgo/series")]
        [ProducesResponseType(typeof(List<SeriesVM>), 200)]
        public async Task<IActionResult> GetCsgoSeries()
        {
            var series = await _manager.GetSeries("CounterStrikeGlobalOffensive");

            return Ok(series);
        }

        // GET api/csgo/matches
        [HttpGet("csgo/matches")]
        [ProducesResponseType(typeof(List<MatchVM>), 200)]
        public async Task<IActionResult> GetCsgoMatches([FromQuery] int? tournamentId)
        {
            // Get most recent matches from any tournament or for specific tournament
            List<MatchVM> matches;
            if (tournamentId.HasValue) matches = await _manager.GetMatches("CounterStrikeGlobalOffensive", tournamentId);
            else matches = await _manager.GetMatches("CounterStrikeGlobalOffensive");

            return Ok(matches);
        }
    }
}
