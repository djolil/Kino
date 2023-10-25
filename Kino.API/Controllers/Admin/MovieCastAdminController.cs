using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kino.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class MovieCastAdminController : ControllerBase
    {
        private readonly IMovieCastService _movieCastService;

        public MovieCastAdminController(IMovieCastService movieCastService)
        {
            _movieCastService = movieCastService;
        }

        // GET: api/MovieCastAdmin/Search/1
        [HttpGet("Search/{id}")]
        public async Task<ActionResult> GetMovieCastsByMovie(int id)
        {
            var casts = await _movieCastService.GetMovieCastsByMovieId(id);
            if (casts == null)
                return NotFound();
            return Ok(casts);
        }

        // POST: api/MovieCastAdmin
        [HttpPost]
        public async Task<ActionResult> AddMovieCast(MovieCastModel cast)
        {
            if (await _movieCastService.AddMovieCast(cast) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/MovieCastAdmin
        [HttpPut]
        public async Task<ActionResult> UpdateMovieCast(MovieCastModel cast)
        {
            if (await _movieCastService.MovieCastExists(cast) == false)
                return NotFound();
            if (await _movieCastService.UpdateMovieCast(cast) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return NoContent();
        }

        // DELETE: api/MovieCastAdmin
        [HttpDelete]
        public async Task<ActionResult> DeleteMovieCast(MovieCastModel cast)
        {
            if (await _movieCastService.MovieCastExists(cast) == false)
                return NotFound();
            if (await _movieCastService.DeleteMovieCast(cast) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return NoContent();
        }
    }
}
