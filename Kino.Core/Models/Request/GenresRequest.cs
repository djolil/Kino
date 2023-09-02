namespace Kino.Core.Models.Request
{
    public class GenresRequest
    {
        public int MovieId { get; set; }

        public IEnumerable<string> Genres { get; set; } = null!;
    }
}
