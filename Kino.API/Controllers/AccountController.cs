using Kino.API.Options;
using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Request;
using Kino.Core.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kino.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOptions<TokenSettings> _tokenSettings;

        public AccountController(IUserService userService, IOptions<TokenSettings> tokenSettings)
        {
            _userService = userService;
            _tokenSettings = tokenSettings;
        }

        // POST: api/Account/Register
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(UserRegisterRequest registerRequest)
        {
            if (await _userService.UserExistsByEmail(registerRequest.Email) == true)
                return Unauthorized("Email address already exists! Please try to login.");
            if (await _userService.RegisterUser(registerRequest) == false)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return StatusCode(StatusCodes.Status201Created);
        }

        // POST: api/Account/Login
        [HttpPost("Login")]
        public async Task<ActionResult> LoginUser(UserLoginRequest loginRequest)
        {
            var loginResponse = await _userService.LoginUser(loginRequest);
            if (loginResponse == null)
                return Unauthorized("Invalid Credentials.");
            var token = GetAccessToken(loginResponse);
            return Ok(token);
        }

        private JwtTokenResponse GetAccessToken(UserLoginResponse payload)
        {
            return new JwtTokenResponse
            {
                AccessToken = GenerateJWT(payload),
                Email = payload.Email,
                Roles = payload.Roles
            };
        }

        private string GenerateJWT(UserLoginResponse payload)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, payload.Id.ToString()),
                new Claim(ClaimTypes.GivenName, payload.FirstName),
                new Claim(ClaimTypes.Surname, payload.LastName),
                new Claim(ClaimTypes.Email, payload.Email)
            };
            foreach (var role in payload.Roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Value.PrivateKey));
            var jwt = new JwtSecurityToken
            (
                issuer: _tokenSettings.Value.Issuer,
                audience: _tokenSettings.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_tokenSettings.Value.ExpirationHours),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
