using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;

namespace Kino.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<ProductionCompany>, ICompanyRepository
    {
        private readonly KinoContext _context;

        public CompanyRepository(KinoContext context) : base(context)
        {
            _context = context;
        }
    }
}
