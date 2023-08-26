namespace Kino.Core.Models.Request
{
    public class MovieLanguageRequest
    {
        public int MovieId { get; set; }

        public int LanguageId { get; set; }

        public int LanguageRoleId { get; set; }
    }
}
