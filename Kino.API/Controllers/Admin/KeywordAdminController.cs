using Kino.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kino.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeywordAdminController : ControllerBase
    {
        private readonly IKeywordService _keywordService;

        public KeywordAdminController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }

        // GET: api/KeywordAdmin
        [HttpGet]
        public async Task<ActionResult> GetAllKeywords()
        {
            var keywords = await _keywordService.GetAllKeywords();
            if (keywords == null)
                return NotFound();
            return Ok(keywords);
        }

        // POST: api/KeywordAdmin
        [HttpPost]
        public async Task<ActionResult> AddKeyword(string name)
        {
            if (await _keywordService.AddKeyword(name) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
