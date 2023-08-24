using Kino.Core.Models.Response;

namespace Kino.Core.Interfaces.Service
{
    public interface ICommonService
    {
        public Task<IEnumerable<GenderResponse>> GetAllGenders();
        public Task<IEnumerable<PersonResponse>?> GetPeopleByName(string name);
    }
}
