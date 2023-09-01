using Kino.Core.Entities;

namespace Kino.Core.Interfaces.Repository
{
    public interface IMovieLanguageRepository : IRepository<MovieLanguage>
    {
        public Task<IEnumerable<MovieLanguage>?> GetMovieLanguagesByMovieId(int id);
    }
}
