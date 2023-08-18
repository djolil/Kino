namespace Kino.Core.Models.Response
{
    public class MovieDetailResponse
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

        public IEnumerable<MovieCastCardResponse> MovieCasts { get; set; } = null!;

        public IEnumerable<MovieCrewHyperTextResponse> MovieCrews { get; set; } = null!;

        public IEnumerable<MovieLanguageResponse> MovieLanguages { get; set; } = null!;

        public IEnumerable<ProductionCompanyResponse> Companies { get; set; } = null!;

        public IEnumerable<CountryResponse> Countries { get; set; } = null!;

        public IEnumerable<GenreResponse> Genres { get; set; } = null!;

        public IEnumerable<KeywordResponse> Keywords { get; set; } = null!;
    }
}
