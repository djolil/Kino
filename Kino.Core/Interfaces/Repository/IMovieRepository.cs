using Kino.Core.Entities;

namespace Kino.Core.Interfaces.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        public Task<IEnumerable<Movie>> GetLatestMovies(int count);
        public Task<Movie?> GetMovieDetail(int id);
        public Task<Movie?> GetMovieDetailAsTracking(int id);
    }
}
