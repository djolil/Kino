using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kino.Infrastructure.Repositories
{
    public class MovieCastRepository : Repository<MovieCast>, IMovieCastRepository
    {
        private readonly KinoContext _context;

        public MovieCastRepository(KinoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieCast>?> GetMovieCastsByMovieId(int id)
        {
            return await _context.MovieCasts
                                    .Include(x => x.Gender)
                                    .Where(x => x.MovieId == id)
                                    .AsNoTracking()
                                    .ToListAsync();
        }
    }
}
