using Kino.Core.Models.Request;
using Kino.Core.Models.Response;

namespace Kino.Core.Interfaces.Service
{
    public interface IMovieCrewService
    {
        public Task<IEnumerable<MovieCrewDetailResponse>?> GetMovieCrewsDetailsByMovieId(int id);
        public Task<bool> AddMovieCrew(MovieCrewRequest movieCrewRequest);
    }
}
