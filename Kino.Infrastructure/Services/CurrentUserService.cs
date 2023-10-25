using Kino.Core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Kino.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int Id => Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims
            .First(x => x.Type == ClaimTypes.NameIdentifier).Value);

        public bool IsAuthenticated => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public string Email => _httpContextAccessor.HttpContext.User.Claims
            .First(x => x.Type == ClaimTypes.Email).Value;

        public string RemoteIpAddress => _httpContextAccessor.HttpContext.Request.Host.Host + ":" +
                                         _httpContextAccessor.HttpContext.Request.Host.Port;
    }
}
