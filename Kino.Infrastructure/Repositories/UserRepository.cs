using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kino.Infrastructure.Repositories
{
    public class UserRepository : Repository<UserAccount>, IUserRepository
    {
        private readonly KinoContext _context;

        public UserRepository(KinoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserAccount?> GetUserByEmail(string email)
        {
            return await _context.UserAccounts
                            .Include(x => x.Roles)
                            .AsNoTracking()
                            .SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
