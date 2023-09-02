namespace Kino.Core.Models.Request
{
    public class CountriesRequest
    {
        public int MovieId { get; set; }

        public IEnumerable<string> Countries { get; set; } = null!;
    }
}
