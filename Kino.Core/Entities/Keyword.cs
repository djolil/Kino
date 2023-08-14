namespace Kino.Core.Entities;

public partial class Keyword
{
    public int Id { get; set; }

    public string KeywordName { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
