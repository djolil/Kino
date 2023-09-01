using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Common;
using Kino.Core.Models.Response;

namespace Kino.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
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

        public async Task<bool> MovieExists(int id)
        {
            return await _movieRepository.AnyAsync(x => x.Id == id);
        }
    }
}
