using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;

namespace Kino.Infrastructure.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly KinoContext _context;

        public CountryRepository(KinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
