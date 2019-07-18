using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Nba;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOnApi.Controllers
{
    [Produces("application/json")]
    [Route("api/general")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly IGeneralManager _Manager;

        public GeneralController(IGeneralManager manager)
        {
            _manager = manager;
        }

        //// GET api/basketball/nba/games/live
        //[HttpGet("nba/games/live")]
        //[ProducesResponseType(typeof(List<GameVM>), 200)]
        //public async Task<IActionResult> GetNbaGames()
        //{
        //    List<GameVM> games = await _manager.GetNbaLiveGames();

        //    return Ok(games);
        //}

        //// GET api/basketball/nba/games/upcoming
        //[HttpGet("nba/games/upcoming")]
        //[ProducesResponseType(typeof(List<GameVM>), 200)]
        //public async Task<IActionResult> GetNbaGamesUpcoming()
        //{
        //    List<GameVM> games = await _manager.GetNbaGamesUpcoming();

        //    return Ok(games);
        //}
    }
}
