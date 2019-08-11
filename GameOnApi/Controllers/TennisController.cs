using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Tennis;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOnApi.Controllers
{
    [Produces("application/json")]
    [Route("api/tennis")]
    [ApiController]
    public class TennisController : ControllerBase
    {
        private readonly ITennisManager _manager;

        public TennisController(ITennisManager manager)
        {
            _manager = manager;
        }

        // GET api/tennis/tournaments
        [HttpGet("tournaments")]
        [ProducesResponseType(typeof(List<TournamentVM>), 200)]
        public async Task<IActionResult> GetTennisTournaments()
        {
            var tournaments = await _manager.GetTournamentsAsync();

            return Ok(tournaments);
        }

        // GET api/tennis/tournaments/5
        [HttpGet("tournaments/{id}")]
        [ProducesResponseType(typeof(InfoApiVM), 200)]
        public async Task<IActionResult> GetTennisTournamentInfo(string id)
        {
            var info = await _manager.GetTournamentInfoAsync(id);

            return Ok(info);
        }

        // GET api/tennis/tournaments/5/schedule
        [HttpGet("tournaments/{id}/schedule")]
        [HttpGet("tournaments/{id}/matches")]
        [ProducesResponseType(typeof(List<SportEventVM>), 200)]
        public async Task<IActionResult> GetTennisTournamentSchedule(string id)
        {
            var schedule = await _manager.GetTournamentScheduleAsync(id);

            return Ok(schedule);
        }

        // GET api/tennis/matches
        [HttpGet("schedule")]
        [HttpGet("matches")]
        [ProducesResponseType(typeof(List<SportEventVM>), 200)]
        public async Task<IActionResult> GetMatchesAsync([FromQuery] string date)
        {
            var schedule = (date == null) ? await _manager.GetMatchesAsyncAsync()
                : await _manager.GetDayScheduleAsync(date);

            return Ok(schedule);
        }
        
        // GET api/tennis/matches/today
        [HttpGet("schedule/today")]
        [HttpGet("matches/today")]
        [ProducesResponseType(typeof(List<SportEventVM>), 200)]
        public async Task<IActionResult> GetMatchesAsyncToday()
        {
            var schedule = await _manager.GetDayScheduleAsync();

            return Ok(schedule);
        }
        
        // GET api/tennis/matches/upcoming
        [HttpGet("schedule/upcoming")]
        [HttpGet("matches/upcoming")]
        [ProducesResponseType(typeof(List<SportEventVM>), 200)]
        public async Task<IActionResult> GetMatchesAsyncUpcoming()
        {
            var schedule = await _manager.GetMatchesAsyncUpcomingAsync();

            return Ok(schedule);
        }
        
        // GET api/tennis/matches/live
        [HttpGet("schedule/live")]
        [HttpGet("matches/live")]
        [ProducesResponseType(typeof(List<SportEventVM>), 200)]
        public async Task<IActionResult> GetMatchesAsyncLive()
        {
            var schedule = await _manager.GetMatchesAsyncLiveAsync();

            return Ok(schedule);
        }

        // GET api/tennis/rankings
        [HttpGet("rankings")]
        [ProducesResponseType(typeof(List<AssociationRankingsVM>), 200)]
        public async Task<IActionResult> GetPlayerRankings()
        {
            var rankings = await _manager.GetPlayerRankingsAsync();

            return Ok(rankings);
        }
    }
}
