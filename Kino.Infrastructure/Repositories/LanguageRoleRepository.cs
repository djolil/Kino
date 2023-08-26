using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;

namespace Kino.Infrastructure.Repositories
{
    public class LanguageRoleRepository : Repository<LanguageRole>, ILanguageRoleRepository
    {
        private readonly KinoContext _context;

        public LanguageRoleRepository(KinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
