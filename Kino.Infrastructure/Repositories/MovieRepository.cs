using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kino.Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly KinoContext _context;

        public MovieRepository(KinoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetLatestMovies(int count)
        {
            return await _context.Movies
                                    .OrderByDescending(x => x.ReleaseDate)
                                    .Take(count)
                                    .AsNoTracking()
                                    .ToListAsync();
        }
    }
}
