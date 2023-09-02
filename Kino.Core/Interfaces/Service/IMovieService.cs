using Kino.Core.Models.Common;
using Kino.Core.Models.Request;
using Kino.Core.Models.Response;

namespace Kino.Core.Interfaces.Service
{
    public interface IMovieService
    {
        public Task<IEnumerable<MovieBannerResponse>> GetHeaderSliderMovies(int count);
        public Task<MovieModel?> GetMovie(int id);
        public Task<MovieDetailResponse?> GetMovieDetail(int id);
        public Task<IEnumerable<MovieSearchResultResponse>?> GetMoviesByName(string name);
        public Task<IEnumerable<string>?> GetCountriesByMovieId(int id);
        public Task<IEnumerable<string>?> GetGenresByMovieId(int id);
        public Task<IEnumerable<string>?> GetKeywordsByMovieId(int id);
        public Task<IEnumerable<string>?> GetCompaniesByMovieId(int id);
        public Task<bool> AddMovie(MovieModel movieModel);
        public Task<bool> AddCountries(CountriesRequest countriesRequest);
        public Task<bool> AddGenres(GenresRequest genresRequest);
        public Task<bool> AddKeywords(KeywordsRequest keywordsRequest);
        public Task<bool> AddCompanies(CompaniesRequest companiesRequest);
        public Task<bool> UpdateMovie(MovieModel movieModel);
        public Task<bool> DeleteMovie(int id);
        public Task<bool> DeleteCountries(CountriesRequest countriesRequest);
        public Task<bool> DeleteGenres(GenresRequest genresRequest);
        public Task<bool> DeleteKeywords(KeywordsRequest keywordsRequest);
        public Task<bool> DeleteCompanies(CompaniesRequest companiesRequest);
        public Task<bool> MovieExists(int id);
    }
}
