using Kino.Core.Models.Request;
using Kino.Core.Models.Response;

namespace Kino.Core.Interfaces.Service
{
    public interface IUserService
    {
        public Task<bool> RegisterUser(UserRegisterRequest userRegisterRequest);
        public Task<UserLoginResponse?> LoginUser(UserLoginRequest userLoginRequest);
        public Task<bool> UserExistsByEmail(string email);
    }
}
