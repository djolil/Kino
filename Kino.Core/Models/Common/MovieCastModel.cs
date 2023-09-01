namespace Kino.Core.Models.Common
{
    public class MovieCastModel
    {
        public int MovieId { get; set; }

        public int PersonId { get; set; }

        public string Gender { get; set; } = null!;

        public string CharacterName { get; set; } = null!;

        public int CastOrder { get; set; }
    }
}
