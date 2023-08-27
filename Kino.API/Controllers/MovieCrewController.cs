using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Kino.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCrewController : ControllerBase
    {
        private readonly IMovieCrewService _movieCrewService;

        public MovieCrewController(IMovieCrewService movieCrewService)
        {
            _movieCrewService = movieCrewService;
        }

        // GET: api/MovieCrew/Search/1
        [HttpGet("Search/{id}")]
        public async Task<ActionResult> GetMovieCrewsDetailsByMovie(int id)
        {
            var crews = await _movieCrewService.GetMovieCrewsDetailsByMovieId(id);
            if (crews == null)
                return NotFound();
            return Ok(crews);
        }

        // POST: api/MovieCrew
        [HttpPost]
        public async Task<ActionResult> AddMovieCrew(MovieCrewRequest crew)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            if (await _movieCrewService.AddMovieCrew(crew) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE: api/MovieCrew
        [HttpDelete]
        public async Task<IActionResult> DeleteMovieCrew(MovieCrewRequest crew)
        {
            if (await _movieCrewService.MovieCrewExists(crew) == false)
                return NotFound();
            if (await _movieCrewService.DeleteMovieCrew(crew) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return NoContent();
        }
    }
}
