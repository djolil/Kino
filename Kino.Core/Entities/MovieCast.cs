namespace Kino.Core.Entities;

public partial class MovieCast
{
    public int MovieId { get; set; }

    public int PersonId { get; set; }

    public int GenderId { get; set; }

    public string CharacterName { get; set; } = null!;

    public int CastOrder { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
