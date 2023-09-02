using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Common;
using Kino.Core.Models.Request;
using Kino.Core.Models.Response;

namespace Kino.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IKeywordRepository _keywordRepository;
        private readonly ICompanyRepository _companyRepository;

        public MovieService(IMovieRepository movieRepository, 
                            ICountryRepository countryRepository,
                            IGenreRepository genreRepository,
                            IKeywordRepository keywordRepository,
                            ICompanyRepository companyRepository)
        {
            _movieRepository = movieRepository;
            _countryRepository = countryRepository;
            _genreRepository = genreRepository;
            _keywordRepository = keywordRepository;
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<MovieBannerResponse>> GetHeaderSliderMovies(int count)
        {
            var movies = await _movieRepository.GetLatestMovies(count);
            var response = movies.Select(x => new MovieBannerResponse
            {
                Id = x.Id,
                Title = x.Title,
                Overview = x.Overview,
                MediaSource = x.MediaSource
            });
            return response;
        }

        public async Task<MovieModel?> GetMovie(int id)
        {
            var movie = await _movieRepository.GetAsync(id);
            if (movie == null)
                return null;
            var response = new MovieModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Budget = movie.Budget,
                Overview = movie.Overview,
                Popularity = movie.Popularity,
                ReleaseDate = movie.ReleaseDate,
                Revenue = movie.Revenue,
                Runtime = movie.Runtime,
                MovieStatus = movie.MovieStatus,
                VoteAverage = movie.VoteAverage,
                VoteCount = movie.VoteCount,
                AgeRating = movie.AgeRating,
                MediaSource = movie.MediaSource
            };
            return response;
        }

        public async Task<MovieDetailResponse?> GetMovieDetail(int id)
        {
            var movie = await _movieRepository.GetMovieDetail(id);
            if (movie == null) 
                return null;
            var response = new MovieDetailResponse
            {
                Id = movie.Id,
                Title = movie.Title,
                Budget = movie.Budget,
                Overview = movie.Overview,
                Popularity = movie.Popularity,
                ReleaseDate = movie.ReleaseDate,
                Revenue = movie.Revenue,
                Runtime = movie.Runtime,
                MovieStatus = movie.MovieStatus,
                VoteAverage = movie.VoteAverage,
                VoteCount = movie.VoteCount,
                AgeRating = movie.AgeRating,
                MediaSource = movie.MediaSource,
                MovieCasts = movie.MovieCasts.Select(x => new MovieCastCardResponse
                {
                    PersonId = x.PersonId,
                    CharacterName = x.CharacterName,
                    CastOrder = x.CastOrder
                }),
                MovieCrews = movie.MovieCrews.Select(x => new MovieCrewHyperTextResponse
                {
                    PersonId = x.PersonId,
                    PersonName = x.Person.PersonName,
                    Department = x.Department.DepartmentName
                }),
                MovieLanguages = movie.MovieLanguages.Select(x => new MovieLanguageResponse
                {
                    Language = x.Language.LanguageName,
                    LanguageRole = x.LanguageRole.LanguageRole1
                }),
                Companies = movie.Companies.Select(x => x.CompanyName),
                Countries = movie.Countries.Select(x => x.CountryName),
                Genres = movie.Genres.Select(x => x.GenreName),
                Keywords = movie.Keywords.Select(x => x.KeywordName)
            };
            return response;
        }

        public async Task<IEnumerable<MovieSearchResultResponse>?> GetMoviesByName(string name)
        {
            var movies = await _movieRepository.FindAsync(x => x.Title.ToUpper().Contains(name.ToUpper()));
            if (movies == null || !movies.Any())
                return null;
            var response = movies.Select(x => new MovieSearchResultResponse
            {
                Id = x.Id,
                Title = x.Title,
                ReleaseDate = x.ReleaseDate,
                MediaSource = x.MediaSource
            });
            return response;
        }

        public async Task<IEnumerable<string>?> GetCountriesByMovieId(int id)
        {
            var movie = await _movieRepository.GetMovieDetail(id);
            if (movie == null || movie.Countries == null || !movie.Countries.Any())
                return null;
            var response = movie.Countries.Select(x => x.CountryName);
            return response;
        }

        public async Task<IEnumerable<string>?> GetGenresByMovieId(int id)
        {
            var movie = await _movieRepository.GetMovieDetail(id);
            if (movie == null || movie.Genres == null || !movie.Genres.Any())
                return null;
            var response = movie.Genres.Select(x => x.GenreName);
            return response;
        }

        public async Task<IEnumerable<string>?> GetKeywordsByMovieId(int id)
        {
            var movie = await _movieRepository.GetMovieDetail(id);
            if (movie == null || movie.Keywords == null || !movie.Keywords.Any())
                return null;
            var response = movie.Keywords.Select(x => x.KeywordName);
            return response;
        }

        public async Task<IEnumerable<string>?> GetCompaniesByMovieId(int id)
        {
            var movie = await _movieRepository.GetMovieDetail(id);
            if (movie == null || movie.Companies == null || !movie.Companies.Any())
                return null;
            var response = movie.Companies.Select(x => x.CompanyName);
            return response;
        }

        public async Task<bool> AddMovie(MovieModel movieModel)
        {
            var movie = new Movie
            {
                Title = movieModel.Title,
                Budget = movieModel.Budget,
                Overview = movieModel.Overview,
                Popularity = movieModel.Popularity,
                ReleaseDate = movieModel.ReleaseDate,
                Revenue = movieModel.Revenue,
                Runtime = movieModel.Runtime,
                MovieStatus = movieModel.MovieStatus,
                VoteAverage = movieModel.VoteAverage,
                VoteCount = movieModel.VoteCount,
                AgeRating = movieModel.AgeRating,
                MediaSource = movieModel.MediaSource
            };
            return await _movieRepository.AddAsync(movie);
        }

        public async Task<bool> AddCountries(CountriesRequest countriesRequest)
        {
            var movie = await _movieRepository.GetMovieDetailAsTracking(countriesRequest.MovieId);
            if (movie == null)
                return false;
            foreach (var countryName in countriesRequest.Countries)
            {
                var country = await _countryRepository.SingleOrDefaultAsync(x => x.CountryName == countryName);
                if (country == null)
                    return false;
                else movie.Countries.Add(country);
            }
            return await _movieRepository.UpdateAsync(movie);
        }

        public async Task<bool> AddGenres(GenresRequest genresRequest)
        {
            var movie = await _movieRepository.GetMovieDetailAsTracking(genresRequest.MovieId);
            if (movie == null)
                return false;
            foreach (var genreName in genresRequest.Genres)
            {
                var genre = await _genreRepository.SingleOrDefaultAsync(x => x.GenreName == genreName);
                if (genre == null)
                    return false;
                else movie.Genres.Add(genre);
            }
            return await _movieRepository.UpdateAsync(movie);
        }

        public async Task<bool> AddKeywords(KeywordsRequest keywordsRequest)
        {
            var movie = await _movieRepository.GetMovieDetailAsTracking(keywordsRequest.MovieId);
            if (movie == null)
                return false;
            foreach (var keywordName in keywordsRequest.Keywords)
            {
                var keyword = await _keywordRepository.SingleOrDefaultAsync(x => x.KeywordName == keywordName);
                if (keyword == null)
                    return false;
                else movie.Keywords.Add(keyword);
            }
            return await _movieRepository.UpdateAsync(movie);
        }

        public async Task<bool> AddCompanies(CompaniesRequest companiesRequest)
        {
            var movie = await _movieRepository.GetMovieDetailAsTracking(companiesRequest.MovieId);
            if (movie == null)
                return false;
            foreach (var companyName in companiesRequest.Companies)
            {
                var company = await _companyRepository.SingleOrDefaultAsync(x => x.CompanyName == companyName);
                if (company == null)
                    return false;
                else movie.Companies.Add(company);
            }
            return await _movieRepository.UpdateAsync(movie);
        }

        public async Task<bool> UpdateMovie(MovieModel movieModel)
        {
            var movie = await _movieRepository.GetAsync(movieModel.Id);
            if (movie == null)
                return false;
            movie.Title = movieModel.Title;
            movie.Budget = movieModel.Budget;
            movie.Overview = movieModel.Overview;
            movie.Popularity = movieModel.Popularity;
            movie.ReleaseDate = movieModel.ReleaseDate;
            movie.Revenue = movieModel.Revenue;
            movie.Runtime = movieModel.Runtime;
            movie.MovieStatus = movieModel.MovieStatus;
            movie.VoteAverage = movieModel.VoteAverage;
            movie.VoteCount = movieModel.VoteCount;
            movie.AgeRating = movieModel.AgeRating;
            movie.MediaSource = movieModel.MediaSource;
            return await _movieRepository.UpdateAsync(movie);
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movie = await _movieRepository.GetAsync(id);
            if (movie == null)
                return false;
            return await _movieRepository.RemoveAsync(movie);
        }

        public async Task<bool> DeleteCountries(CountriesRequest countriesRequest)
        {
            var movie = await _movieRepository.GetMovieDetailAsTracking(countriesRequest.MovieId);
            if (movie == null || movie.Countries == null || !movie.Countries.Any())
                return false;
            foreach (var countryName in countriesRequest.Countries)
            {
                var country = await _countryRepository.SingleOrDefaultAsync(x => x.CountryName == countryName);
                if (country == null)
                    return false;
                else (movie.Countries as List<Country>)?.RemoveAll(x => x.Id == country.Id);
            }
            return await _movieRepository.UpdateAsync(movie);
        }

        public async Task<bool> DeleteGenres(GenresRequest genresRequest)
        {
            var movie = await _movieRepository.GetMovieDetailAsTracking(genresRequest.MovieId);
            if (movie == null || movie.Genres == null || !movie.Genres.Any())
                return false;
            foreach (var genreName in genresRequest.Genres)
            {
                var genre = await _genreRepository.SingleOrDefaultAsync(x => x.GenreName == genreName);
                if (genre == null)
                    return false;
                else (movie.Genres as List<Genre>)?.RemoveAll(x => x.Id == genre.Id);
            }
            return await _movieRepository.UpdateAsync(movie);
        }

        public async Task<bool> DeleteKeywords(KeywordsRequest keywordsRequest)
        {
            var movie = await _movieRepository.GetMovieDetailAsTracking(keywordsRequest.MovieId);
            if (movie == null || movie.Keywords == null || !movie.Keywords.Any())
                return false;
            foreach (var keywordName in keywordsRequest.Keywords)
            {
                var keyword = await _keywordRepository.SingleOrDefaultAsync(x => x.KeywordName == keywordName);
                if (keyword == null)
                    return false;
                else (movie.Keywords as List<Keyword>)?.RemoveAll(x => x.Id == keyword.Id);
            }
            return await _movieRepository.UpdateAsync(movie);
        }

        public async Task<bool> DeleteCompanies(CompaniesRequest companiesRequest)
        {
            var movie = await _movieRepository.GetMovieDetailAsTracking(companiesRequest.MovieId);
            if (movie == null || movie.Companies == null || !movie.Companies.Any())
                return false;
            foreach (var companyName in companiesRequest.Companies)
            {
                var company = await _companyRepository.SingleOrDefaultAsync(x => x.CompanyName == companyName);
                if (company == null)
                    return false;
                else (movie.Companies as List<ProductionCompany>)?.RemoveAll(x => x.Id == company.Id);
            }
            return await _movieRepository.UpdateAsync(movie);
        }

        public async Task<bool> MovieExists(int id)
        {
            return await _movieRepository.AnyAsync(x => x.Id == id);
        }
    }
}
