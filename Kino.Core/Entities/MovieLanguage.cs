namespace Kino.Core.Entities;

public partial class MovieLanguage
{
    public int MovieId { get; set; }

    public int LanguageId { get; set; }

    public int LanguageRoleId { get; set; }

    public virtual Language Language { get; set; } = null!;

    public virtual LanguageRole LanguageRole { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
