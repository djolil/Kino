namespace Kino.Core.Models.Request
{
    public class KeywordsRequest
    {
        public int MovieId { get; set; }

        public IEnumerable<string> Keywords { get; set; } = null!;
    }
}
