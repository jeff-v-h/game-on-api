using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public IActionResult Create([FromBody] DotaVM data)
        {
            if (data == null) return BadRequest(new ErrorResponse(400,
                "Please provide details to create a project."));

            var dotaVM = _manager.Create(data);

            // Project is successfully created. Return the uri to the created project.
            return CreatedAtRoute("GetDota", new { id = dotaVM.Id }, dotaVM);
        }

        // POST api/dota?id=5ccf23bd111979561c08b76a
        [HttpPost("update")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public IActionResult Update([BindRequired, FromQuery] string id, [FromBody] DotaVM data)
        {
            bool isUpdated = _manager.Update(id, data);

            if (!isUpdated) return NotFound(new ErrorResponse(404, 
                $"Document with id '{id}' was not found. No update was executed."));

            return NoContent();
        }

        // DELETE api/dota?id=5ccfed25b620305d94f541f0
        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public IActionResult Delete([BindRequired, FromQuery] string id)
        {
            bool isDeleted = _manager.Delete(id);

            if (!isDeleted) return NotFound(new ErrorResponse(404,
                $"Document with id '{id}' was not found. No delete was executed."));

            return NoContent();
        }
    }
}
