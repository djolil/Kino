namespace Kino.Core.Models.Response
{
    public class MovieCrewDetailResponse
    {
        public int MovieId { get; set; }

        public int PersonId { get; set; }

        public string PersonName { get; set; } = null!;

        public string Department { get; set; } = null!;
    }
}
