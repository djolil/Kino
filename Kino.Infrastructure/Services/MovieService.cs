using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Response;

namespace Kino.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieBannerResponseModel>> GetHeaderSliderMovies(int count)
        {
            var movies = await _movieRepository.GetLatestMovies(count);
            var response = movies.Select(x => new MovieBannerResponseModel
            {
                Id = x.Id,
                Title = x.Title,
                Overview = x.Overview,
                MediaSource = x.MediaSource
            });
            return response;
        }
    }
}
