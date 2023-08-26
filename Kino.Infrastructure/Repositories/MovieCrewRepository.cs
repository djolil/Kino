using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kino.Infrastructure.Repositories
{
    public class MovieCrewRepository : Repository<MovieCrew>, IMovieCrewRepository
    {
        private readonly KinoContext _context;

        public MovieCrewRepository(KinoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieCrew>?> GetMovieCrewsDetailsByMovieId(int id)
        {
            return await _context.MovieCrews
                                    .Include(x => x.Person)
                                    .Include(x => x.Department)
                                    .Where(x => x.MovieId == id)
                                    .AsNoTracking()
                                    .ToListAsync();
        }
    }
}
