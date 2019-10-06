using com.gameon.domain.Interfaces;
using com.gameon.domain.Models.AppModels;
using com.gameon.domain.Models.ViewModels.Nba;
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
        
        // GET api/basketball/nba/games/live
        [HttpGet("nba/games/live")]
        [ProducesResponseType(typeof(List<NbaGameVM>), 200)]
        public async Task<IActionResult> GetNbaGames()
        {
            List<NbaGameVM> games = await _manager.GetNbaLiveGamesAsync();

            return Ok(games);
        }

        // GET api/basketball/nba/games/upcoming
        [HttpGet("nba/games/upcoming")]
        [ProducesResponseType(typeof(List<NbaGameVM>), 200)]
        public async Task<IActionResult> GetNbaGamesUpcoming()
        {
            List<NbaGameVM> games = await _manager.GetNbaGamesUpcomingAsync();

            return Ok(games);
        }

        // GET api/basketball/nba/games/5750
        [HttpGet("nba/games/{gameId}")]
        [ProducesResponseType(typeof(NbaGameDetailsVM), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        public async Task<IActionResult> GetNbaGameDetails(string gameId)
        {
            NbaGameDetailsVM game = await _manager.GetNbaGameDetailsAsync(gameId);

            if (game == null) return NotFound(
                new ErrorResponse(404, $"Nba game with id '{gameId}' was not found."));

            return Ok(game);
        }

        // GET api/basketball/nba/schedule
        // GET api/basketball/nba/games
        [HttpGet("nba/schedule")]
        [HttpGet("nba/games")]
        [ProducesResponseType(typeof(List<NbaGameVM>), 200)]
        public async Task<IActionResult> GetNbaScheduleAsync()
        {
            var games = await _manager.GetNbaScheduleAsync();

            return Ok(games);
        }

        // GET api/basketball/nba/teams
        [HttpGet("nba/teams")]
        [ProducesResponseType(typeof(List<NbaTeamVM>), 200)]
        public async Task<IActionResult> GetNbaTeams()
        {
            var teams = await _manager.GetNbaTeamsAsync();

            return Ok(teams);
        }
    }
}
