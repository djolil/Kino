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

        // GET: api/Department
        [HttpGet("Department")]
        public async Task<ActionResult> GetDepartments()
        {
            var departments = await _commonService.GetAllDepartments();
            return Ok(departments);
        }

        // GET: api/Language
        [HttpGet("Language")]
        public async Task<ActionResult> GetLanguages()
        {
            var languages = await _commonService.GetAllLanguages();
            return Ok(languages);
        }

        // GET: api/LanguageRole
        [HttpGet("LanguageRole")]
        public async Task<ActionResult> GetLanguageRoles()
        {
            var roles = await _commonService.GetAllLanguageRoles();
            return Ok(roles);
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
