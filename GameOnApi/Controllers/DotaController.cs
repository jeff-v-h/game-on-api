using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        public IActionResult GetDota(ObjectId id)
        {
            var dota = _manager.Get();

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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
