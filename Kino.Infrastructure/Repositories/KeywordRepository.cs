using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;

namespace Kino.Infrastructure.Repositories
{
    public class KeywordRepository : Repository<Keyword>, IKeywordRepository
    {
        private readonly KinoContext _context;

        public KeywordRepository(KinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
