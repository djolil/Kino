using Kino.Core.Models.Common;
using Kino.Core.Models.Response;

namespace Kino.Core.Interfaces.Service
{
    public interface IMovieService
    {
        public Task<IEnumerable<MovieBannerResponse>> GetHeaderSliderMovies(int count);
        public Task<MovieModel?> GetMovie(int id);
        public Task<MovieDetailResponse?> GetMovieDetail(int id);
        public Task<IEnumerable<MovieSearchResultResponse>?> GetMoviesByName(string name);
        public Task<bool> AddMovie(MovieModel movieModel);
        public Task<bool> UpdateMovie(MovieModel movieModel);
        public Task<bool> DeleteMovie(int id);
        public Task<bool> MovieExists(int id);
    }
}
