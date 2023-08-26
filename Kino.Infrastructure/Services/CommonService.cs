using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Response;

namespace Kino.Infrastructure.Services
{
    public class CommonService : ICommonService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ILanguageRoleRepository _languageRoleRepository;
        private readonly IPersonRepository _personRepository;

        public CommonService(IGenderRepository genderRepository, IDepartmentRepository departmentRepository, ILanguageRepository languageRepository, ILanguageRoleRepository languageRoleRepository, IPersonRepository personRepository)
        {
            _genderRepository = genderRepository;
            _departmentRepository = departmentRepository;
            _languageRepository = languageRepository;
            _languageRoleRepository = languageRoleRepository;
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

        public async Task<IEnumerable<DepartmentResponse>> GetAllDepartments()
        {
            var departments = await _departmentRepository.GetAllAsync();
            var response = departments.Select(x => new DepartmentResponse
            {
                Id = x.Id,
                DepartmentName = x.DepartmentName
            });
            return response;
        }

        public async Task<IEnumerable<LanguageResponse>> GetAllLanguages()
        {
            var languages = await _languageRepository.GetAllAsync();
            var response = languages.Select(x => new LanguageResponse
            {
                Id = x.Id,
                LanguageCode = x.LanguageCode,
                LanguageName = x.LanguageName
            });
            return response;
        }

        public async Task<IEnumerable<LanguageRoleResponse>> GetAllLanguageRoles()
        {
            var roles = await _languageRoleRepository.GetAllAsync();
            var response = roles.Select(x => new LanguageRoleResponse
            {
                Id = x.Id,
                LanguageRole1 = x.LanguageRole1
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
