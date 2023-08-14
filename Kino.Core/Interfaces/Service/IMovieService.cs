using Kino.Core.Models.Response;

namespace Kino.Core.Interfaces.Service
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieBannerResponseModel>> GetHeaderSliderMovies(int count);
    }
}
