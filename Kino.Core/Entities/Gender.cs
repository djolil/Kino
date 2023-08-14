namespace Kino.Core.Entities;

public partial class Gender
{
    public int Id { get; set; }

    public string Gender1 { get; set; } = null!;

    public virtual ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
}
