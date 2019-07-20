using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Nba;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOnApi.Controllers
{
    [Produces("application/json")]
    [Route("api/basketball")]
    [ApiController]
    public class NbaController : ControllerBase
    {
        private readonly INbaManager _manager;

        public NbaController(INbaManager manager)
        {
            _manager = manager;
        }

        // GET api/basketball/nba/schedule
        [HttpGet("nba/schedule")]
        [ProducesResponseType(typeof(List<GameVM>), 200)]
        public async Task<IActionResult> GetNbaScheduleAsync()
        {
            var games = await _manager.GetNbaScheduleAsync();

            return Ok(games);
        }
        
        // GET api/basketball/nba/games/live
        [HttpGet("nba/games/live")]
        [ProducesResponseType(typeof(List<GameVM>), 200)]
        public async Task<IActionResult> GetNbaGames()
        {
            List<GameVM> games = await _manager.GetNbaLiveGamesAsync();

            return Ok(games);
        }

        // GET api/basketball/nba/games/upcoming
        [HttpGet("nba/games/upcoming")]
        [ProducesResponseType(typeof(List<GameVM>), 200)]
        public async Task<IActionResult> GetNbaGamesUpcomingAsync()
        {
            List<GameVM> games = await _manager.GetNbaGamesUpcomingAsync();

            return Ok(games);
        }

        // GET api/basketball/nba/teams
        [HttpGet("nba/teams")]
        [ProducesResponseType(typeof(List<NbaTeamVM>), 200)]
        public async Task<IActionResult> GetNbaTeamsAsync()
        {
            var teams = await _manager.GetNbaTeamsAsync();

            return Ok(teams);
        }
    }
}
