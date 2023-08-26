using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Kino.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieLanguageController : ControllerBase
    {
        private readonly IMovieLanguageService _movieLanguageService;

        public MovieLanguageController(IMovieLanguageService movieLanguageService)
        {
            _movieLanguageService = movieLanguageService;
        }

        // GET: api/MovieLanguage/Search/1
        [HttpGet("Search/{id}")]
        public async Task<ActionResult> GetMovieLanguagesDetailsByMovie(int id)
        {
            var languages = await _movieLanguageService.GetMovieLanguagesDetailsByMovieId(id);
            if (languages == null)
                return NotFound();
            return Ok(languages);
        }

        // POST: api/MovieLanguage
        [HttpPost]
        public async Task<ActionResult> AddMovieLanguage(MovieLanguageRequest language)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            if (await _movieLanguageService.AddMovieLanguage(language) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
