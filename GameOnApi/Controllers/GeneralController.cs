using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels.General;
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
        private readonly IGeneralManager _manager;

        public GeneralController(IGeneralManager manager)
        {
            _manager = manager;
        }

        // GET api/general/events/week
        [HttpGet("events/week")]
        [ProducesResponseType(typeof(SortedWeekEventsVM), 200)]
        public async Task<IActionResult> GetSortedWeekEvents()
        {
            var events = await _manager.GetSortedWeekEventsAsync();

            return Ok(events);
        }

        // GET api/general/events
        [HttpGet("events")]
        [ProducesResponseType(typeof(SortedEventsVM), 200)]
        public async Task<IActionResult> GetSortedEvents()
        {
            var events = await _manager.GetEventsAsync();

            return Ok(events);
        }
    }
}
