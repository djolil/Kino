namespace Kino.API.Options
{
    public class TokenSettings
    {
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public string PrivateKey { get; set; } = null!;
        public int ExpirationHours { get; set; }
    }
}
