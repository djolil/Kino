namespace Kino.Core.Interfaces.Service
{
    public interface ICompanyService
    {
        public Task<IEnumerable<string>?> GetAllCompanies();
        public Task<bool> AddCompany(string name);
    }
}
