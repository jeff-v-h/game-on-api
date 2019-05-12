using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Football;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameOnApi.Controllers
{
    [Produces("application/json")]
    [Route("api/epl")]
    [ApiController]
    public class EplController : ControllerBase
    {
        private readonly IEplManager _manager;

        public EplController(IEplManager manager)
        {
            _manager = manager;
        }

        // GET api/epl/schedule
        [HttpGet("schedule")]
        [ProducesResponseType(typeof(List<FixtureVM>), 200)]
        public async Task<IActionResult> GetSchedule()
        {
            var schedule = await _manager.GetSchedule();

            return Ok(schedule);
        }

        // GET api/epl/teams
        [HttpGet("teams")]
        [ProducesResponseType(typeof(List<TeamVM>), 200)]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _manager.GetTeams();

            return Ok(teams);
        }
    }
}
