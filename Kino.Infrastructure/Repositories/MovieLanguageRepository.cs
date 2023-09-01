using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kino.Infrastructure.Repositories
{
    public class MovieLanguageRepository : Repository<MovieLanguage>, IMovieLanguageRepository
    {
        private readonly KinoContext _context;

        public MovieLanguageRepository(KinoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieLanguage>?> GetMovieLanguagesByMovieId(int id)
        {
            return await _context.MovieLanguages
                                    .Include(x => x.Language)
                                    .Include(x => x.LanguageRole)
                                    .Where(x => x.MovieId == id)
                                    .AsNoTracking()
                                    .ToListAsync();
        }
    }
}
