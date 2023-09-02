namespace Kino.Core.Models.Request
{
    public class CompaniesRequest
    {
        public int MovieId { get; set; }

        public IEnumerable<string> Companies { get; set; } = null!;
    }
}
