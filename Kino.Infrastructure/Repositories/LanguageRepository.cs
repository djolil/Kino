using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;

namespace Kino.Infrastructure.Repositories
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        private readonly KinoContext _context;

        public LanguageRepository(KinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
