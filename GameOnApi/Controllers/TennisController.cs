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

        // GET api/tennis/schedule
        // GET api/tennis/tournaments
        [HttpGet("schedule")]
        [HttpGet("tournaments")]
        [ProducesResponseType(typeof(List<TournamentVM>), 200)]
        public async Task<IActionResult> GetTennisTournaments()
        {
            var tournaments = await _manager.GetTournaments();

            return Ok(tournaments);
        }

        // GET api/tennis/tournaments/5
        [HttpGet("tournaments/{id}")]
        [ProducesResponseType(typeof(InfoApiVM), 200)]
        public async Task<IActionResult> GetTennisTournamentInfo(string id)
        {
            var info = await _manager.GetTournamentInfo(id);

            return Ok(info);
        }

        // GET api/tennis/tournaments/5/schedule
        [HttpGet("tournaments/{id}/schedule")]
        [ProducesResponseType(typeof(List<SportEventVM>), 200)]
        public async Task<IActionResult> GetTennisTournamentSchedule(string id)
        {
            var schedule = await _manager.GetTournamentSchedule(id);

            return Ok(schedule);
        }
    }
}
