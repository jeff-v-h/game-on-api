using com.gameon.domain.Interfaces;
using com.gameon.domain.Models.ViewModels.Football;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOnApi.Controllers
{
    [Produces("application/json")]
    [Route("api/football")]
    [ApiController]
    public class FootballController : ControllerBase
    {
        private readonly IFootballManager _manager;

        public FootballController(IFootballManager manager)
        {
            _manager = manager;
        }

        // GET api/football/epl/schedule
        [HttpGet("epl/schedule")]
        [ProducesResponseType(typeof(List<FixtureVM>), 200)]
        public async Task<IActionResult> GetEplSchedule()
        {
            var schedule = await _manager.GetScheduleAsync("epl");

            return Ok(schedule);
        }
        
        // GET api/football/epl/games/live
        [HttpGet("epl/games/live")]
        [ProducesResponseType(typeof(List<FixtureVM>), 200)]
        public async Task<IActionResult> GetEplLiveGames()
        {
            var schedule = await _manager.GetLiveGamesAsync("epl");

            return Ok(schedule);
        }
        
        // GET api/football/epl/games/upcoming
        [HttpGet("epl/games/upcoming")]
        [ProducesResponseType(typeof(List<FixtureVM>), 200)]
        public async Task<IActionResult> GetEplGamesUpcoming()
        {
            var schedule = await _manager.GetGamesUpcomingAsync("epl");

            return Ok(schedule);
        }

        // GET api/football/epl/teams
        [HttpGet("epl/teams")]
        [ProducesResponseType(typeof(List<TeamVM>), 200)]
        public async Task<IActionResult> GetEplTeams()
        {
            var teams = await _manager.GetTeamsAsync("epl");

            return Ok(teams);
        }

        // GET api/football/championsleague/schedule
        [HttpGet("championsleague/schedule")]
        [ProducesResponseType(typeof(List<FixtureVM>), 200)]
        public async Task<IActionResult> GetChampionsLeagueSchedule()
        {
            var schedule = await _manager.GetScheduleAsync("championsleague");

            return Ok(schedule);
        }

        // GET api/football/championsleague/games/live
        [HttpGet("championsleague/games/live")]
        [ProducesResponseType(typeof(List<FixtureVM>), 200)]
        public async Task<IActionResult> GetChampionsLeagueLiveGames()
        {
            var schedule = await _manager.GetLiveGamesAsync("championsleague");

            return Ok(schedule);
        }

        // GET api/football/championsleague/games/upcoming
        [HttpGet("championsleague/games/upcoming")]
        [ProducesResponseType(typeof(List<FixtureVM>), 200)]
        public async Task<IActionResult> GetChampionsLeagueGamesUpcoming()
        {
            var schedule = await _manager.GetGamesUpcomingAsync("championsleague");

            return Ok(schedule);
        }

        // GET api/football/championsleague/teams
        [HttpGet("championsleague/teams")]
        [ProducesResponseType(typeof(List<TeamVM>), 200)]
        public async Task<IActionResult> GetChampionsLeagueTeams()
        {
            var teams = await _manager.GetTeamsAsync("championsleague");

            return Ok(teams);
        }

        // GET api/football/europaleague/schedule
        [HttpGet("europaleague/schedule")]
        [ProducesResponseType(typeof(List<FixtureVM>), 200)]
        public async Task<IActionResult> GetEuropaLeagueSchedule()
        {
            var schedule = await _manager.GetScheduleAsync("europaleague");

            return Ok(schedule);
        }

        // GET api/football/europaleague/games/live
        [HttpGet("europaleague/games/live")]
        [ProducesResponseType(typeof(List<FixtureVM>), 200)]
        public async Task<IActionResult> GetEuropaLeagueLiveGames()
        {
            var schedule = await _manager.GetLiveGamesAsync("europaleague");

            return Ok(schedule);
        }

        // GET api/football/europaleague/games/upcoming
        [HttpGet("europaleague/games/upcoming")]
        [ProducesResponseType(typeof(List<FixtureVM>), 200)]
        public async Task<IActionResult> GetEuropaLeagueGamesUpcoming()
        {
            var schedule = await _manager.GetGamesUpcomingAsync("europaleague");

            return Ok(schedule);
        }

        // GET api/football/europaleague/teams
        [HttpGet("europaleague/teams")]
        [ProducesResponseType(typeof(List<TeamVM>), 200)]
        public async Task<IActionResult> GetEuropaLeagueTeams()
        {
            var teams = await _manager.GetTeamsAsync("europaleague");

            return Ok(teams);
        }
    }
}
