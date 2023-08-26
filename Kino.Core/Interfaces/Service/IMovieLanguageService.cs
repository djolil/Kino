using Kino.Core.Models.Request;
using Kino.Core.Models.Response;

namespace Kino.Core.Interfaces.Service
{
    public interface IMovieLanguageService
    {
        public Task<IEnumerable<MovieLanguageDetailResponse>?> GetMovieLanguagesDetailsByMovieId(int id);
        public Task<bool> AddMovieLanguage(MovieLanguageRequest movieLanguageRequest);
    }
}
