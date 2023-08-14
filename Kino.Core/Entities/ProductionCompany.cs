namespace Kino.Core.Entities;

public partial class ProductionCompany
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
