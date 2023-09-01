using Kino.Core.Models.Common;

namespace Kino.Core.Interfaces.Service
{
    public interface IMovieLanguageService
    {
        public Task<IEnumerable<MovieLanguageModel>?> GetMovieLanguagesByMovieId(int id);
        public Task<bool> AddMovieLanguage(MovieLanguageModel movieLanguageRequest);
        public Task<bool> DeleteMovieLanguage(MovieLanguageModel movieLanguageRequest);
        public Task<bool> MovieLanguageExists(MovieLanguageModel movieLanguageRequest);
    }
}
