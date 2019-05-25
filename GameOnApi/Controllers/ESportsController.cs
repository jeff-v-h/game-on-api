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

        // GET api/dota/tournaments
        [HttpGet("dota/tournaments")]
        [ProducesResponseType(typeof(List<ESportsTournamentVM>), 200)]
        public async Task<IActionResult> GetDotaTournaments()
        {
            var tournaments = await _manager.GetDotaTournaments();

            return Ok(tournaments);
        }

        // GET api/dota/teams
        [HttpGet("dota/teams")]
        [ProducesResponseType(typeof(List<ESportsTeamVM>), 200)]
        public async Task<IActionResult> GetDotaTeams()
        {
            var teams = await _manager.GetDotaTeams();

            return Ok(teams);
        }

        // GET api/lol/tournaments
        [HttpGet("lol/tournaments")]
        [ProducesResponseType(typeof(List<ESportsTournamentVM>), 200)]
        public async Task<IActionResult> GetLolTournaments()
        {
            var tournaments = await _manager.GetLolTournaments();

            return Ok(tournaments);
        }

        // GET api/lol/teams
        [HttpGet("lol/teams")]
        [ProducesResponseType(typeof(List<ESportsTeamVM>), 200)]
        public async Task<IActionResult> GetLolTeams()
        {
            var teams = await _manager.GetLolTeams();

            return Ok(teams);
        }

        // GET api/overwatch/tournaments
        [HttpGet("overwatch/tournaments")]
        [ProducesResponseType(typeof(List<ESportsTournamentVM>), 200)]
        public async Task<IActionResult> GetOverwatchTournaments()
        {
            var tournaments = await _manager.GetOverwatchTournaments();

            return Ok(tournaments);
        }

        // GET api/overwatch/teams
        [HttpGet("overwatch/teams")]
        [ProducesResponseType(typeof(List<ESportsTeamVM>), 200)]
        public async Task<IActionResult> GetOverwatchTeams()
        {
            var teams = await _manager.GetOverwatchTeams();

            return Ok(teams);
        }

        // GET api/csgo/tournaments
        [HttpGet("csgo/tournaments")]
        [ProducesResponseType(typeof(List<ESportsTournamentVM>), 200)]
        public async Task<IActionResult> GetCsgoTournaments()
        {
            var tournaments = await _manager.GetCsgoTournaments();

            return Ok(tournaments);
        }

        // GET api/csgo/teams
        [HttpGet("csgo/teams")]
        [ProducesResponseType(typeof(List<ESportsTeamVM>), 200)]
        public async Task<IActionResult> GetCsgoTeams()
        {
            var teams = await _manager.GetCsgoTeams();

            return Ok(teams);
        }
    }
}
