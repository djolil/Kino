namespace Kino.Core.Models.Response
{
    public class CountryResponse
    {
        public int Id { get; set; }

        public string CountryIsoCode { get; set; } = null!;

        public string CountryName { get; set; } = null!;
    }
}
