using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Common;
using Kino.Core.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kino.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
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

        // GET: api/MovieAdmin/Country/1
        [HttpGet("Country/{id}")]
        public async Task<ActionResult> GetCountries(int id)
        {
            var countries = await _movieService.GetCountriesByMovieId(id);
            if (countries == null)
                return NotFound();
            return Ok(countries);
        }

        // GET: api/MovieAdmin/Genre/1
        [HttpGet("Genre/{id}")]
        public async Task<ActionResult> GetGenres(int id)
        {
            var genres = await _movieService.GetGenresByMovieId(id);
            if (genres == null)
                return NotFound();
            return Ok(genres);
        }

        // GET: api/MovieAdmin/Keyword/1
        [HttpGet("Keyword/{id}")]
        public async Task<ActionResult> GetKeywords(int id)
        {
            var keywords = await _movieService.GetKeywordsByMovieId(id);
            if (keywords == null)
                return NotFound();
            return Ok(keywords);
        }

        // GET: api/MovieAdmin/Company/1
        [HttpGet("Company/{id}")]
        public async Task<ActionResult> GetCompanies(int id)
        {
            var companies = await _movieService.GetCompaniesByMovieId(id);
            if (companies == null)
                return NotFound();
            return Ok(companies);
        }

        // POST: api/MovieAdmin
        [HttpPost]
        public async Task<ActionResult> AddMovie(MovieModel movie)
        {
            if (await _movieService.AddMovie(movie) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // POST: api/MovieAdmin/Country
        [HttpPost("Country")]
        public async Task<ActionResult> AddCountries(CountriesRequest countries)
        {
            if (await _movieService.AddCountries(countries) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // POST: api/MovieAdmin/Genre
        [HttpPost("Genre")]
        public async Task<ActionResult> AddGenres(GenresRequest genres)
        {
            if (await _movieService.AddGenres(genres) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // POST: api/MovieAdmin/Keyword
        [HttpPost("Keyword")]
        public async Task<ActionResult> AddKeywords(KeywordsRequest keywords)
        {
            if (await _movieService.AddKeywords(keywords) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // POST: api/MovieAdmin/Company
        [HttpPost("Company")]
        public async Task<ActionResult> AddCompanies(CompaniesRequest companies)
        {
            if (await _movieService.AddCompanies(companies) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/MovieAdmin
        [HttpPut]
        public async Task<ActionResult> UpdateMovie(MovieModel movie)
        {
            if (await _movieService.MovieExists(movie.Id) == false)
                return NotFound();
            if (await _movieService.UpdateMovie(movie) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return NoContent();
        }

        // DELETE: api/MovieAdmin/3
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            if (await _movieService.MovieExists(id) == false)
                return NotFound();
            if (await _movieService.DeleteMovie(id) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return NoContent();
        }

        // DELETE: api/MovieAdmin/Country
        [HttpDelete("Country")]
        public async Task<ActionResult> DeleteCountries(CountriesRequest countries)
        {
            if (await _movieService.DeleteCountries(countries) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE: api/MovieAdmin/Genre
        [HttpDelete("Genre")]
        public async Task<ActionResult> DeleteGenres(GenresRequest genres)
        {
            if (await _movieService.DeleteGenres(genres) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE: api/MovieAdmin/Keyword
        [HttpDelete("Keyword")]
        public async Task<ActionResult> DeleteKeywords(KeywordsRequest keywords)
        {
            if (await _movieService.DeleteKeywords(keywords) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE: api/MovieAdmin/Company
        [HttpDelete("Company")]
        public async Task<ActionResult> DeleteCompanies(CompaniesRequest companies)
        {
            if (await _movieService.DeleteCompanies(companies) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
