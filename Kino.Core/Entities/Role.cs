namespace Kino.Core.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<UserAccount> Users { get; set; } = new List<UserAccount>();
}
