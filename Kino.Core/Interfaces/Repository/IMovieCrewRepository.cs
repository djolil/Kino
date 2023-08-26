using Kino.Core.Entities;

namespace Kino.Core.Interfaces.Repository
{
    public interface IMovieCrewRepository : IRepository<MovieCrew>
    {
        public Task<IEnumerable<MovieCrew>?> GetMovieCrewsDetailsByMovieId(int id);
    }
}
