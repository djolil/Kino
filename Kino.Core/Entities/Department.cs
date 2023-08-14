namespace Kino.Core.Entities;

public partial class Department
{
    public int Id { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<MovieCrew> MovieCrews { get; set; } = new List<MovieCrew>();
}
