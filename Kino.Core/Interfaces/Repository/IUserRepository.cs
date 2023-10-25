using Kino.Core.Entities;

namespace Kino.Core.Interfaces.Repository
{
    public interface IUserRepository : IRepository<UserAccount>
    {
        public Task<UserAccount?> GetUserByEmail(string email);
    }
}
