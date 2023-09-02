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

        public async Task<Movie?> GetMovieDetail(int id)
        {
            return await _context.Movies
                                    .Include(x => x.MovieCasts)
                                    .Include(x => x.MovieCrews)
                                        .ThenInclude(x => x.Person)
                                    .Include(x => x.MovieCrews)
                                        .ThenInclude(x => x.Department)
                                    .Include(x => x.MovieLanguages)
                                        .ThenInclude(x => x.Language)
                                    .Include(x => x.MovieLanguages)
                                        .ThenInclude(x => x.LanguageRole)
                                    .Include(x => x.Companies)
                                    .Include(x => x.Countries)
                                    .Include(x => x.Genres)
                                    .Include(x => x.Keywords)
                                    .AsNoTracking()
                                    .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Movie?> GetMovieDetailAsTracking(int id)
        {
            return await _context.Movies
                                    .Include(x => x.Companies)
                                    .Include(x => x.Countries)
                                    .Include(x => x.Genres)
                                    .Include(x => x.Keywords)
                                    .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
