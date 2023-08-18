namespace Kino.Core.Models.Response
{
    public class MovieSearchResultResponse
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateOnly ReleaseDate { get; set; }

        public string? MediaSource { get; set; }
    }
}
