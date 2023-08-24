using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;

namespace Kino.Infrastructure.Repositories
{
    public class GenderRepository : Repository<Gender>, IGenderRepository
    {
        private readonly KinoContext _context;

        public GenderRepository(KinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
