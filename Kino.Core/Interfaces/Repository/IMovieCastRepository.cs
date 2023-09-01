using Kino.Core.Entities;

namespace Kino.Core.Interfaces.Repository
{
    public interface IMovieCastRepository : IRepository<MovieCast>
    {
        public Task<IEnumerable<MovieCast>?> GetMovieCastsByMovieId(int id);
    }
}
