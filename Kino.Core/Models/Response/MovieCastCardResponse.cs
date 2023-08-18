namespace Kino.Core.Models.Response
{
    public class MovieCastCardResponse
    {
        public int PersonId { get; set; }

        public string CharacterName { get; set; } = null!;

        public int CastOrder { get; set; }
    }
}
