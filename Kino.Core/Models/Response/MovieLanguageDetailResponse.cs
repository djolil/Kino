namespace Kino.Core.Models.Response
{
    public class MovieLanguageDetailResponse
    {
        public int MovieId { get; set; }

        public int LanguageId { get; set; }

        public string LanguageName { get; set; } = null!;

        public int LanguageRoleId { get; set; }

        public string LanguageRoleName { get; set; } = null!;
    }
}
