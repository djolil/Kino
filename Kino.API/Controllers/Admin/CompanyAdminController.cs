using Kino.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kino.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyAdminController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyAdminController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/CompanyAdmin
        [HttpGet]
        public async Task<ActionResult> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompanies();
            if (companies == null)
                return NotFound();
            return Ok(companies);
        }

        // POST: api/CompanyAdmin
        [HttpPost]
        public async Task<ActionResult> AddCompany(string name)
        {
            if (await _companyService.AddCompany(name) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
