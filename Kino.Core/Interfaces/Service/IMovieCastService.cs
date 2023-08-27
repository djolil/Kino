using Kino.Core.Models.Common;

namespace Kino.Core.Interfaces.Service
{
    public interface IMovieCastService
    {
        public Task<IEnumerable<MovieCastModel>?> GetMovieCastsByMovieId(int id);
        public Task<bool> AddMovieCast(MovieCastModel movieCastModel);
        public Task<bool> UpdateMovieCast(MovieCastModel movieCastModel);
        public Task<bool> DeleteMovieCast(MovieCastModel movieCastModel);
        public Task<bool> MovieCastExists(MovieCastModel movieCastModel);
    }
}
