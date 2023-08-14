namespace Kino.Core.Entities;

public partial class MovieCrew
{
    public int MovieId { get; set; }

    public int PersonId { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
