using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Response;
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

        //// GET: api/Movies
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        //{
        //    if (_context.Movies == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.Movies.ToListAsync();
        //}

        //// GET: api/Movies/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Movie>> GetMovie(int id)
        //{
        //    if (_context.Movies == null)
        //    {
        //        return NotFound();
        //    }
        //    var movie = await _context.Movies.FindAsync(id);

        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    return movie;
        //}

        //// PUT: api/Movies/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMovie(int id, Movie movie)
        //{
        //    if (id != movie.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(movie).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MovieExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Movies
        //[HttpPost]
        //public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        //{
        //    if (_context.Movies == null)
        //    {
        //        return Problem("Entity set 'KinoContext.Movies'  is null.");
        //    }

        //    _context.Movies.Add(movie);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        //}

        //// DELETE: api/Movies/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMovie(int id)
        //{
        //    if (_context.Movies == null)
        //    {
        //        return NotFound();
        //    }
        //    var movie = await _context.Movies.FindAsync(id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Movies.Remove(movie);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool MovieExists(int id)
        //{
        //    return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
