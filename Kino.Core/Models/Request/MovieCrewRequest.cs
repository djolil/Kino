namespace Kino.Core.Models.Request
{
    public class MovieCrewRequest
    {
        public int MovieId { get; set; }

        public int PersonId { get; set; }

        public string Department { get; set; } = null!;
    }
}
