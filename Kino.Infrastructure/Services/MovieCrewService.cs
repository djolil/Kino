using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Request;
using Kino.Core.Models.Response;

namespace Kino.Infrastructure.Services
{
    public class MovieCrewService : IMovieCrewService
    {
        private readonly IMovieCrewRepository _movieCrewRepository;

        public MovieCrewService(IMovieCrewRepository movieCrewRepository)
        {
            _movieCrewRepository = movieCrewRepository;
        }

        public async Task<IEnumerable<MovieCrewDetailResponse>?> GetMovieCrewsDetailsByMovieId(int id)
        {
            var crews = await _movieCrewRepository.GetMovieCrewsDetailsByMovieId(id);
            if (crews == null || !crews.Any())
                return null;
            var response = crews.Select(x => new MovieCrewDetailResponse
            {
                MovieId = x.MovieId,
                PersonId = x.PersonId,
                PersonName = x.Person.PersonName,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department.DepartmentName
            });
            return response;
        }

        public async Task<bool> AddMovieCrew(MovieCrewRequest movieCrewRequest)
        {
            var crew = new MovieCrew
            {
                MovieId = movieCrewRequest.MovieId,
                PersonId = movieCrewRequest.PersonId,
                DepartmentId = movieCrewRequest.DepartmentId
            };
            return await _movieCrewRepository.AddAsync(crew);
        }
    }
}
