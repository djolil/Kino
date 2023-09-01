using Kino.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kino.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonAdminController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonAdminController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/PersonAdmin/Search/Абвгд
        [HttpGet("Search/{name}")]
        public async Task<ActionResult> GetSearchPeopleResult(string name)
        {
            var people = await _personService.GetPeopleByName(name);
            if (people == null)
                return NotFound();
            return Ok(people);
        }

        // POST: api/PersonAdmin
        [HttpPost]
        public async Task<ActionResult> AddPerson(string name)
        {
            if (await _personService.AddPerson(name) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
