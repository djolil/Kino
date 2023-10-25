namespace Kino.Core.Models.Response
{
    public class UserLoginResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public IEnumerable<string> Roles { get; set; } = null!;
    }
}
