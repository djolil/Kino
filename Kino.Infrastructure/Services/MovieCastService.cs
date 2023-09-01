using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Common;

namespace Kino.Infrastructure.Services
{
    public class MovieCastService : IMovieCastService
    {
        private readonly IMovieCastRepository _movieCastRepository;
        private readonly IGenderRepository _genderRepository;

        public MovieCastService(IMovieCastRepository movieCastRepository, IGenderRepository genderRepository)
        {
            _movieCastRepository = movieCastRepository;
            _genderRepository = genderRepository;
        }

        public async Task<IEnumerable<MovieCastModel>?> GetMovieCastsByMovieId(int id)
        {
            var casts = await _movieCastRepository.GetMovieCastsByMovieId(id);
            if (casts == null || !casts.Any())
                return null;
            var response = casts.Select(x => new MovieCastModel
            {
                MovieId = x.MovieId,
                PersonId = x.PersonId,
                Gender = x.Gender.Gender1,
                CharacterName = x.CharacterName,
                CastOrder = x.CastOrder
            });
            return response;
        }

        public async Task<bool> AddMovieCast(MovieCastModel movieCastModel)
        {
            var gender = await _genderRepository.SingleOrDefaultAsync(x => x.Gender1 == movieCastModel.Gender);
            if (gender == null) 
                return false;
            var cast = new MovieCast
            {
                MovieId = movieCastModel.MovieId,
                PersonId = movieCastModel.PersonId,
                GenderId = gender.Id,
                CharacterName = movieCastModel.CharacterName,
                CastOrder = movieCastModel.CastOrder
            };
            return await _movieCastRepository.AddAsync(cast);
        }

        public async Task<bool> UpdateMovieCast(MovieCastModel movieCastModel)
        {
            var gender = await _genderRepository.SingleOrDefaultAsync(x => x.Gender1 == movieCastModel.Gender);
            if (gender == null)
                return false;
            var cast = await _movieCastRepository.SingleOrDefaultAsync(x => x.MovieId == movieCastModel.MovieId
                                                                            && x.PersonId == movieCastModel.PersonId
                                                                            && x.GenderId == gender.Id);
            if (cast == null) 
                return false;
            cast.CharacterName = movieCastModel.CharacterName;
            cast.CastOrder = movieCastModel.CastOrder;
            return await _movieCastRepository.UpdateAsync(cast);
        }

        public async Task<bool> DeleteMovieCast(MovieCastModel movieCastModel)
        {
            var gender = await _genderRepository.SingleOrDefaultAsync(x => x.Gender1 == movieCastModel.Gender);
            if (gender == null)
                return false;
            var cast = await _movieCastRepository.SingleOrDefaultAsync(x => x.MovieId == movieCastModel.MovieId
                                                                            && x.PersonId == movieCastModel.PersonId
                                                                            && x.GenderId == gender.Id);
            if (cast == null)
                return false;
            return await _movieCastRepository.RemoveAsync(cast);
        }

        public async Task<bool> MovieCastExists(MovieCastModel movieCastModel)
        {
            var gender = await _genderRepository.SingleOrDefaultAsync(x => x.Gender1 == movieCastModel.Gender);
            if (gender == null)
                return false;
            return await _movieCastRepository.AnyAsync(x => x.MovieId == movieCastModel.MovieId
                                                            && x.PersonId == movieCastModel.PersonId
                                                            && x.GenderId == gender.Id);
        }
    }
}
