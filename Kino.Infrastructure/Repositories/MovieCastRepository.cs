using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;

namespace Kino.Infrastructure.Repositories
{
    public class MovieCastRepository : Repository<MovieCast>, IMovieCastRepository
    {
        private readonly KinoContext _context;

        public MovieCastRepository(KinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
