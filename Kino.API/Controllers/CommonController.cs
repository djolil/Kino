using Kino.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kino.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        // GET: api/Gender
        [HttpGet("Gender")]
        public async Task<ActionResult> GetGenders()
        {
            var genders = await _commonService.GetAllGenders();
            return Ok(genders);
        }

        // GET: api/Person/Search/Абвгд
        [HttpGet("Person/Search/{name}")]
        public async Task<ActionResult> GetSearchPeopleResult(string name)
        {
            var people = await _commonService.GetPeopleByName(name);
            if (people == null)
                return NotFound();
            return Ok(people);
        }
    }
}
