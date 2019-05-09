using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.Football;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult GetSchedule()
        {
            var schedule = _manager.GetSchedule();

            return Ok(schedule);
        }

        // GET api/epl/teams
        [HttpGet("teams")]
        [ProducesResponseType(typeof(List<TeamVM>), 200)]
        public IActionResult GetTeams()
        {
            var teams = _manager.GetTeams();

            return Ok(teams);
        }
    }
}
