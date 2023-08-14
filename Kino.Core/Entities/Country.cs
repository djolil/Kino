namespace Kino.Core.Entities;

public partial class Country
{
    public int Id { get; set; }

    public string CountryIsoCode { get; set; } = null!;

    public string CountryName { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
