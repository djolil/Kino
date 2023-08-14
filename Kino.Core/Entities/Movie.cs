namespace Kino.Core.Entities;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Budget { get; set; }

    public string Overview { get; set; } = null!;

    public int Popularity { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public int Revenue { get; set; }

    public int Runtime { get; set; }

    public string MovieStatus { get; set; } = null!;

    public decimal VoteAverage { get; set; }

    public int VoteCount { get; set; }

    public string AgeRating { get; set; } = null!;

    public string? MediaSource { get; set; }

    public virtual ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();

    public virtual ICollection<MovieCrew> MovieCrews { get; set; } = new List<MovieCrew>();

    public virtual ICollection<MovieLanguage> MovieLanguages { get; set; } = new List<MovieLanguage>();

    public virtual ICollection<ProductionCompany> Companies { get; set; } = new List<ProductionCompany>();

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    public virtual ICollection<Keyword> Keywords { get; set; } = new List<Keyword>();
}
