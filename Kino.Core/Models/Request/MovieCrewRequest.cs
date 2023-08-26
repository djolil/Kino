namespace Kino.Core.Models.Request
{
    public class MovieCrewRequest
    {
        public int MovieId { get; set; }

        public int PersonId { get; set; }

        public int DepartmentId { get; set; }
    }
}
