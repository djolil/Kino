using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;

namespace Kino.Infrastructure.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly KinoContext _context;

        public RoleRepository(KinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
