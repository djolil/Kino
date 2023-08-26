﻿using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;
using Kino.Core.Models.Request;
using Kino.Core.Models.Response;

namespace Kino.Infrastructure.Services
{
    public class MovieLanguageService : IMovieLanguageService
    {
        private readonly IMovieLanguageRepository _movieLanguageRepository;

        public MovieLanguageService(IMovieLanguageRepository movieLanguageRepository)
        {
            _movieLanguageRepository = movieLanguageRepository;
        }

        public async Task<IEnumerable<MovieLanguageDetailResponse>?> GetMovieLanguagesDetailsByMovieId(int id)
        {
            var languages = await _movieLanguageRepository.GetMovieLanguagesDetailsByMovieId(id);
            if (languages == null || !languages.Any())
                return null;
            var response = languages.Select(x => new MovieLanguageDetailResponse
            {
                MovieId = x.MovieId,
                LanguageId = x.LanguageId,
                LanguageName = x.Language.LanguageName,
                LanguageRoleId = x.LanguageRoleId,
                LanguageRoleName = x.LanguageRole.LanguageRole1
            });
            return response;
        }

        public async Task<bool> AddMovieLanguage(MovieLanguageRequest movieLanguageRequest)
        {
            var language = new MovieLanguage
            {
                MovieId = movieLanguageRequest.MovieId,
                LanguageId = movieLanguageRequest.LanguageId,
                LanguageRoleId = movieLanguageRequest.LanguageRoleId
            };
            return await _movieLanguageRepository.AddAsync(language);
        }
    }
}
