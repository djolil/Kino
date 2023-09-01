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
        private readonly IDepartmentRepository _departmentRepository;

        public MovieCrewService(IMovieCrewRepository movieCrewRepository, IDepartmentRepository departmentRepository)
        {
            _movieCrewRepository = movieCrewRepository;
            _departmentRepository = departmentRepository;
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
                Department = x.Department.DepartmentName
            });
            return response;
        }

        public async Task<bool> AddMovieCrew(MovieCrewRequest movieCrewRequest)
        {
            var department = await _departmentRepository.SingleOrDefaultAsync(x => x.DepartmentName == movieCrewRequest.Department);
            if (department == null) 
                return false;
            var crew = new MovieCrew
            {
                MovieId = movieCrewRequest.MovieId,
                PersonId = movieCrewRequest.PersonId,
                DepartmentId = department.Id
            };
            return await _movieCrewRepository.AddAsync(crew);
        }

        public async Task<bool> DeleteMovieCrew(MovieCrewRequest movieCrewRequest)
        {
            var department = await _departmentRepository.SingleOrDefaultAsync(x => x.DepartmentName == movieCrewRequest.Department);
            if (department == null)
                return false;
            var crew = await _movieCrewRepository.SingleOrDefaultAsync(x => x.MovieId == movieCrewRequest.MovieId
                                                                            && x.PersonId == movieCrewRequest.PersonId
                                                                            && x.DepartmentId == department.Id);
            if (crew == null)
                return false;
            return await _movieCrewRepository.RemoveAsync(crew);
        }

        public async Task<bool> MovieCrewExists(MovieCrewRequest movieCrewRequest)
        {
            var department = await _departmentRepository.SingleOrDefaultAsync(x => x.DepartmentName == movieCrewRequest.Department);
            if (department == null)
                return false;
            return await _movieCrewRepository.AnyAsync(x => x.MovieId == movieCrewRequest.MovieId
                                                            && x.PersonId == movieCrewRequest.PersonId
                                                            && x.DepartmentId == department.Id);
        }
    }
}
