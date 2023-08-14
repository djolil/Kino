namespace Kino.Core.Entities;

public partial class Language
{
    public int Id { get; set; }

    public string LanguageCode { get; set; } = null!;

    public string LanguageName { get; set; } = null!;

    public virtual ICollection<MovieLanguage> MovieLanguages { get; set; } = new List<MovieLanguage>();
}
