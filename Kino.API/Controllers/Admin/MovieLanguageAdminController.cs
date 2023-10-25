using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kino.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class MovieLanguageAdminController : ControllerBase
    {
        private readonly IMovieLanguageService _movieLanguageService;

        public MovieLanguageAdminController(IMovieLanguageService movieLanguageService)
        {
            _movieLanguageService = movieLanguageService;
        }

        // GET: api/MovieLanguageAdmin/Search/1
        [HttpGet("Search/{id}")]
        public async Task<ActionResult> GetMovieLanguagesByMovie(int id)
        {
            var movieLanguages = await _movieLanguageService.GetMovieLanguagesByMovieId(id);
            if (movieLanguages == null)
                return NotFound();
            return Ok(movieLanguages);
        }

        // POST: api/MovieLanguageAdmin
        [HttpPost]
        public async Task<ActionResult> AddMovieLanguage(MovieLanguageModel movieLanguage)
        {
            if (await _movieLanguageService.AddMovieLanguage(movieLanguage) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE: api/MovieLanguageAdmin
        [HttpDelete]
        public async Task<ActionResult> DeleteMovieLanguage(MovieLanguageModel movieLanguage)
        {
            if (await _movieLanguageService.MovieLanguageExists(movieLanguage) == false)
                return NotFound();
            if (await _movieLanguageService.DeleteMovieLanguage(movieLanguage) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return NoContent();
        }
    }
}
