namespace Kino.Core.Interfaces.Service
{
    public interface ICryptoService
    {
        public string GenerateSalt();
        public string GenerateHashedPassword(string password, string salt);
    }
}
