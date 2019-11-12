using com.gameon.domain.Interfaces;
using com.gameon.domain.Models.ViewModels.General;
using com.gameon.domain.Models.ViewModels.Nba;
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

        /*
         * GET for specific sports in a given week (mainly for testing purposes)
         */
        [HttpGet("events/week/{sport}")]
        [ProducesResponseType(typeof(SortedWeekEventsVM), 200)]
        public async Task<IActionResult> GetSportSortedWeekEvents(string sport, [FromQuery] string startDate)
        {
            var events = await _manager.GetSportSortedWeekEventsAsync(sport, startDate);

            return Ok(events);
        }

        // GET all sports sorted for a specific week (from today by default)
        // GET api/general/events/week
        [HttpGet("events/week")]
        [ProducesResponseType(typeof(SortedWeekEventsVM), 200)]
        public async Task<IActionResult> GetSortedWeekEvents([FromQuery] string startDate)
        {
            var events = await _manager.GetSortedWeekEventsAsync(startDate);

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
