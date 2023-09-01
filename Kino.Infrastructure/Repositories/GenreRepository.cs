using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;

namespace Kino.Infrastructure.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly KinoContext _context;

        public GenreRepository(KinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
