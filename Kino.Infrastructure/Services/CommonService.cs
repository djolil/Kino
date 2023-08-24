using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Response;

namespace Kino.Infrastructure.Services
{
    public class CommonService : ICommonService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IPersonRepository _personRepository;

        public CommonService(IGenderRepository genderRepository, IPersonRepository personRepository)
        {
            _genderRepository = genderRepository;
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<GenderResponse>> GetAllGenders()
        {
            var genders = await _genderRepository.GetAllAsync();
            var response = genders.Select(x => new GenderResponse
            {
                Id = x.Id,
                Gender1 = x.Gender1
            });
            return response;
        }

        public async Task<IEnumerable<PersonResponse>?> GetPeopleByName(string name)
        {
            var people = await _personRepository.FindAsync(x => x.PersonName.ToUpper().Contains(name.ToUpper()));
            if (people == null || !people.Any())
                return null;
            var response = people.Select(x => new PersonResponse
            {
                Id = x.Id,
                PersonName = x.PersonName
            });
            return response;
        }
    }
}
