﻿using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace Kino.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCastController : ControllerBase
    {
        private readonly IMovieCastService _movieCastService;

        public MovieCastController(IMovieCastService movieCastService)
        {
            _movieCastService = movieCastService;
        }

        // GET: api/MovieCast/Search/1
        [HttpGet("Search/{id}")]
        public async Task<ActionResult> GetMovieCastsByMovie(int id)
        {
            var casts = await _movieCastService.GetMovieCastsByMovieId(id);
            if (casts == null)
                return NotFound();
            return Ok(casts);
        }

        // POST: api/MovieCast
        [HttpPost]
        public async Task<ActionResult> AddMovieCast(MovieCastModel cast)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            if (await _movieCastService.AddMovieCast(cast) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/MovieCast
        [HttpPut]
        public async Task<IActionResult> UpdateMovieCast(MovieCastModel cast)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            if (await _movieCastService.MovieCastExists(cast) == false)
                return NotFound();
            if (await _movieCastService.UpdateMovieCast(cast) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return NoContent();
        }
    }
}
