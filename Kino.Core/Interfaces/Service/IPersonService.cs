using Kino.Core.Models.Response;

namespace Kino.Core.Interfaces.Service
{
    public interface IPersonService
    {
        public Task<IEnumerable<PersonResponse>?> GetPeopleByName(string name);
        public Task<bool> AddPerson(string name);
    }
}
