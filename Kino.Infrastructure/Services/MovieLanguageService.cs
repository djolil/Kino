using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Common;
using Kino.Core.Models.Response;

namespace Kino.Infrastructure.Services
{
    public class MovieLanguageService : IMovieLanguageService
    {
        private readonly IMovieLanguageRepository _movieLanguageRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ILanguageRoleRepository _languageRoleRepository;

        public MovieLanguageService(IMovieLanguageRepository movieLanguageRepository, ILanguageRepository languageRepository, ILanguageRoleRepository languageRoleRepository)
        {
            _movieLanguageRepository = movieLanguageRepository;
            _languageRepository = languageRepository;
            _languageRoleRepository = languageRoleRepository;
        }

        public async Task<IEnumerable<MovieLanguageModel>?> GetMovieLanguagesByMovieId(int id)
        {
            var movieLanguages = await _movieLanguageRepository.GetMovieLanguagesByMovieId(id);
            if (movieLanguages == null || !movieLanguages.Any())
                return null;
            var response = movieLanguages.Select(x => new MovieLanguageModel
            {
                MovieId = x.MovieId,
                Language = x.Language.LanguageName,
                LanguageRole = x.LanguageRole.LanguageRole1
            });
            return response;
        }

        public async Task<bool> AddMovieLanguage(MovieLanguageModel movieLanguageRequest)
        {
            var language = await _languageRepository.SingleOrDefaultAsync(x => x.LanguageName == movieLanguageRequest.Language);
            if (language == null) 
                return false;
            var languageRole = await _languageRoleRepository.SingleOrDefaultAsync(x => x.LanguageRole1 == movieLanguageRequest.LanguageRole);
            if (languageRole == null) 
                return false;
            var movieLanguage = new MovieLanguage
            {
                MovieId = movieLanguageRequest.MovieId,
                LanguageId = language.Id,
                LanguageRoleId = languageRole.Id
            };
            return await _movieLanguageRepository.AddAsync(movieLanguage);
        }

        public async Task<bool> DeleteMovieLanguage(MovieLanguageModel movieLanguageRequest)
        {
            var language = await _languageRepository.SingleOrDefaultAsync(x => x.LanguageName == movieLanguageRequest.Language);
            if (language == null)
                return false;
            var languageRole = await _languageRoleRepository.SingleOrDefaultAsync(x => x.LanguageRole1 == movieLanguageRequest.LanguageRole);
            if (languageRole == null)
                return false;
            var movieLanguage = await _movieLanguageRepository.SingleOrDefaultAsync(x => x.MovieId == movieLanguageRequest.MovieId
                                                                            && x.LanguageId == language.Id
                                                                            && x.LanguageRoleId == languageRole.Id);
            if (movieLanguage == null)
                return false;
            return await _movieLanguageRepository.RemoveAsync(movieLanguage);
        }

        public async Task<bool> MovieLanguageExists(MovieLanguageModel movieLanguageRequest)
        {
            var language = await _languageRepository.SingleOrDefaultAsync(x => x.LanguageName == movieLanguageRequest.Language);
            if (language == null)
                return false;
            var languageRole = await _languageRoleRepository.SingleOrDefaultAsync(x => x.LanguageRole1 == movieLanguageRequest.LanguageRole);
            if (languageRole == null)
                return false;
            return await _movieLanguageRepository.AnyAsync(x => x.MovieId == movieLanguageRequest.MovieId
                                                            && x.LanguageId == language.Id
                                                            && x.LanguageRoleId == languageRole.Id);
        }
    }
}
