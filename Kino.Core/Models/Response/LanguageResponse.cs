namespace Kino.Core.Models.Response
{
    public class LanguageResponse
    {
        public int Id { get; set; }

        public string LanguageCode { get; set; } = null!;

        public string LanguageName { get; set; } = null!;
    }
}
