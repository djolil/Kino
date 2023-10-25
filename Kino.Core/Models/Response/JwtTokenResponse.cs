namespace Kino.Core.Models.Response
{
    public class JwtTokenResponse
    {
        public string AccessToken { get; set; } = null!;
        public string Email { get; set; } = null!;
        public IEnumerable<string> Roles { get; set; } = null!;
    }
}
