using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace Kino.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieAdminController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieAdminController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/MovieAdmin/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovie(id);
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }

        // POST: api/MovieAdmin
        [HttpPost]
        public async Task<ActionResult> AddMovie(MovieModel movie)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            if (await _movieService.AddMovie(movie) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/MovieAdmin
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(MovieModel movie)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            if (await _movieService.MovieExists(movie.Id) == false)
                return NotFound();
            if (await _movieService.UpdateMovie(movie) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return NoContent();
        }

        // DELETE: api/MovieAdmin/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (await _movieService.MovieExists(id) == false)
                return NotFound();
            if (await _movieService.DeleteMovie(id) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return NoContent();
        }
    }
}
