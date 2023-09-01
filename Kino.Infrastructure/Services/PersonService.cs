using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Response;

namespace Kino.Infrastructure.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
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

        public async Task<bool> AddPerson(string name)
        {
            var person = new Person
            {
                PersonName = name
            };
            return await _personRepository.AddAsync(person);
        }
    }
}
