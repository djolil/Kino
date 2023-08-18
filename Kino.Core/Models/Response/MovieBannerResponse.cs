namespace Kino.Core.Models.Response
{
    public class MovieBannerResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Overview { get; set; } = null!;
        public string? MediaSource { get; set; }
    }
}
