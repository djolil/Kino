using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kino.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class MovieCrewAdminController : ControllerBase
    {
        private readonly IMovieCrewService _movieCrewService;

        public MovieCrewAdminController(IMovieCrewService movieCrewService)
        {
            _movieCrewService = movieCrewService;
        }

        // GET: api/MovieCrewAdmin/Search/1
        [HttpGet("Search/{id}")]
        public async Task<ActionResult> GetMovieCrewsDetailsByMovie(int id)
        {
            var crews = await _movieCrewService.GetMovieCrewsDetailsByMovieId(id);
            if (crews == null)
                return NotFound();
            return Ok(crews);
        }

        // POST: api/MovieCrewAdmin
        [HttpPost]
        public async Task<ActionResult> AddMovieCrew(MovieCrewRequest crew)
        {
            if (await _movieCrewService.AddMovieCrew(crew) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE: api/MovieCrewAdmin
        [HttpDelete]
        public async Task<ActionResult> DeleteMovieCrew(MovieCrewRequest crew)
        {
            if (await _movieCrewService.MovieCrewExists(crew) == false)
                return NotFound();
            if (await _movieCrewService.DeleteMovieCrew(crew) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return NoContent();
        }
    }
}
