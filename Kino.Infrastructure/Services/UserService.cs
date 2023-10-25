using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Request;
using Kino.Core.Models.Response;

namespace Kino.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;

        public UserService(IUserRepository userRepository, ICryptoService cryptoService)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
        }

        public async Task<bool> RegisterUser(UserRegisterRequest userRegisterRequest)
        {
            var salt = _cryptoService.GenerateSalt();
            var hashedPassword = _cryptoService.GenerateHashedPassword(userRegisterRequest.Password, salt);
            var user = new UserAccount
            {
                FirstName = userRegisterRequest.FirstName,
                LastName = userRegisterRequest.LastName,
                Email = userRegisterRequest.Email,
                Salt = salt,
                HashedPassword = hashedPassword
            };
            return await _userRepository.AddAsync(user);
        }

        public async Task<UserLoginResponse?> LoginUser(UserLoginRequest userLoginRequest)
        {
            var user = await _userRepository.GetUserByEmail(userLoginRequest.Email);
            if (user == null)
                return null;
            var hashedPassword = _cryptoService.GenerateHashedPassword(userLoginRequest.Password, user.Salt);
            if (hashedPassword != user.HashedPassword)
                return null;
            var response = new UserLoginResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = user.Roles.Select(x => x.RoleName)
            };
            return response;
        }

        public async Task<bool> UserExistsByEmail(string email)
        {
            return await _userRepository.AnyAsync(x => x.Email == email);
        }
    }
}
