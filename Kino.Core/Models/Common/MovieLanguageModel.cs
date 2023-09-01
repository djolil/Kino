namespace Kino.Core.Models.Common
{
    public class MovieLanguageModel
    {
        public int MovieId { get; set; }

        public string Language { get; set; } = null!;

        public string LanguageRole { get; set; } = null!;
    }
}
