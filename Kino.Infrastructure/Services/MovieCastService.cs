using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Common;

namespace Kino.Infrastructure.Services
{
    public class MovieCastService : IMovieCastService
    {
        private readonly IMovieCastRepository _movieCastRepository;

        public MovieCastService(IMovieCastRepository movieCastRepository)
        {
            _movieCastRepository = movieCastRepository;
        }

        public async Task<IEnumerable<MovieCastModel>?> GetMovieCastsByMovieId(int id)
        {
            var casts = await _movieCastRepository.FindAsync(x => x.MovieId == id);
            if (casts == null || !casts.Any())
                return null;
            var response = casts.Select(x => new MovieCastModel
            {
                MovieId = x.MovieId,
                PersonId = x.PersonId,
                GenderId = x.GenderId,
                CharacterName = x.CharacterName,
                CastOrder = x.CastOrder
            });
            return response;
        }

        public async Task<bool> AddMovieCast(MovieCastModel movieCastModel)
        {
            var cast = new MovieCast
            {
                MovieId = movieCastModel.MovieId,
                PersonId = movieCastModel.PersonId,
                GenderId = movieCastModel.GenderId,
                CharacterName = movieCastModel.CharacterName,
                CastOrder = movieCastModel.CastOrder
            };
            return await _movieCastRepository.AddAsync(cast);
        }

        public async Task<bool> UpdateMovieCast(MovieCastModel movieCastModel)
        {
            var cast = await _movieCastRepository.SingleOrDefaultAsync(x => x.MovieId == movieCastModel.MovieId
                                                                            && x.PersonId == movieCastModel.PersonId
                                                                            && x.GenderId == movieCastModel.GenderId);
            if (cast == null) 
                return false;
            cast.CharacterName = movieCastModel.CharacterName;
            cast.CastOrder = movieCastModel.CastOrder;
            return await _movieCastRepository.UpdateAsync(cast);
        }

        public async Task<bool> DeleteMovieCast(MovieCastModel movieCastModel)
        {
            var cast = await _movieCastRepository.SingleOrDefaultAsync(x => x.MovieId == movieCastModel.MovieId
                                                                            && x.PersonId == movieCastModel.PersonId
                                                                            && x.GenderId == movieCastModel.GenderId);
            if (cast == null)
                return false;
            return await _movieCastRepository.RemoveAsync(cast);
        }

        public async Task<bool> MovieCastExists(MovieCastModel movieCastModel)
        {
            return await _movieCastRepository.AnyAsync(x => x.MovieId == movieCastModel.MovieId
                                                            && x.PersonId == movieCastModel.PersonId
                                                            && x.GenderId == movieCastModel.GenderId);
        }
    }
}
