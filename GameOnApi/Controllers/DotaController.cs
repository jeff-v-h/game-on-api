using com.gameon.domain.Interfaces;
using com.gameon.domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameOnApi.Controllers
{
    [Produces("application/json")]
    [Route("dota")]
    [ApiController]
    public class DotaController : ControllerBase
    {
        private readonly IDotaManager _manager;

        public DotaController(IDotaManager manager)
        {
            _manager = manager;
        }

        // GET api/dota
        [HttpGet("")]
        [ProducesResponseType(typeof(DotaVM), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public IActionResult GetDota()
        {
            var dota = _manager.Get();

            if (dota == null) return NotFound(new ErrorResponse(404,
                $"Dota information could not be found."));

            return Ok(dota);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
