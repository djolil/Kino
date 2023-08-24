using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;

namespace Kino.Infrastructure.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly KinoContext _context;

        public PersonRepository(KinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
