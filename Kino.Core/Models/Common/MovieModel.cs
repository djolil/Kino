namespace Kino.Core.Models.Common
{
    public class MovieModel
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
    }
}
