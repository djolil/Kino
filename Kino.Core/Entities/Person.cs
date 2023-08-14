namespace Kino.Core.Entities;

public partial class Person
{
    public int Id { get; set; }

    public string PersonName { get; set; } = null!;

    public virtual ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();

    public virtual ICollection<MovieCrew> MovieCrews { get; set; } = new List<MovieCrew>();
}
