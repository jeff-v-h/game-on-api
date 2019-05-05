using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace GameOnApi.Controllers
{
    [Produces("application/json")]
    [Route("api/dota")]
    [ApiController]
    public class DotaController : ControllerBase
    {
        private readonly IDotaManager _manager;

        public DotaController(IDotaManager manager)
        {
            _manager = manager;
        }

        // GET api/dota
        [HttpGet("", Name = "GetDota")]
        [ProducesResponseType(typeof(DotaVM), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public IActionResult GetDota([BindRequired, FromQuery] string id)
        {
            var dota = _manager.Get(id);

            if (dota == null) return NotFound(new ErrorResponse(404,
                $"Dota information could not be found."));

            return Ok(dota);
        }

        // POST api/dota
        [HttpPost]
        [ProducesResponseType(typeof(DotaVM), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Create([FromBody] DotaVM data)
        {
            if (data == null) return BadRequest(new ErrorResponse(400,
                "Please provide details to create a project."));

            var dotaVM = await _manager.Create(data);

            // Project is successfully created. Return the uri to the created project.
            return CreatedAtRoute("GetDota", new { id = dotaVM.Id }, dotaVM);
        }

        // PUT api/dota?id=5ccf23bd111979561c08b76a
        // TODO id length 24
        [HttpPost]
        public IActionResult Update([BindRequired, FromQuery] string id, [FromBody] DotaVM data)
        {

            if (id != data.Id) return BadRequest(new ErrorResponse(400, 
                "The new ticket's id does not match the old id."));

            bool ticketIsUpdated = _manager.Update(data);
            if (!ticketIsUpdated) return NotFound(new ErrorResponse(400, 
                $"Ticket with id '{id}' was not found. No update was executed."));

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
