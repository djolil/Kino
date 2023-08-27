using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace Kino.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movie/Banner/3
        [HttpGet("Banner/{count}")]
        public async Task<ActionResult> GetHeaderSliderMovies(int count)
        {
            var movies = await _movieService.GetHeaderSliderMovies(count);
            return Ok(movies);
        }

        // GET: api/Movie/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovie(id);
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }

        // GET: api/Movie/Details/1
        [HttpGet("Details/{id}")]
        public async Task<ActionResult> GetMovieDetail(int id)
        {
            var movie = await _movieService.GetMovieDetail(id);
            if (movie == null) 
                return NotFound();
            return Ok(movie);
        }

        // GET: api/Movie/Search/Абвгд
        [HttpGet("Search/{name}")]
        public async Task<ActionResult> GetSearchMoviesResult(string name)
        {
            var movies = await _movieService.GetMoviesByName(name);
            if (movies == null) 
                return NotFound();
            return Ok(movies);
        }

        // POST: api/Movie
        [HttpPost]
        public async Task<ActionResult> AddMovie(MovieModel movie)
        {
            if (!ModelState.IsValid) 
                return UnprocessableEntity(ModelState);
            if (await _movieService.AddMovie(movie) == false) 
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Movie
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

        // DELETE: api/Movie/3
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
