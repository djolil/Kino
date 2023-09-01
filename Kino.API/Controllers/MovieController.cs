using Kino.Core.Interfaces.Service;
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
    }
}
