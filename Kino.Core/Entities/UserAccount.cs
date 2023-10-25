namespace Kino.Core.Entities;

public partial class UserAccount
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
