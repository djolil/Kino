using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;

namespace Kino.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<string>?> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllAsync();
            if (companies == null || !companies.Any())
                return null;
            var response = companies.Select(x => x.CompanyName);
            return response;
        }

        public async Task<bool> AddCompany(string name)
        {
            var company = new ProductionCompany
            {
                CompanyName = name
            };
            return await _companyRepository.AddAsync(company);
        }
    }
}
