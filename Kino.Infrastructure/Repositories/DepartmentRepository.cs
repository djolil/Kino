using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;

namespace Kino.Infrastructure.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly KinoContext _context;

        public DepartmentRepository(KinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
