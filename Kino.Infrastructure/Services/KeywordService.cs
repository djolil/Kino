using Kino.Core.Entities;
using Kino.Core.Interfaces.Repository;
using Kino.Core.Interfaces.Service;

namespace Kino.Infrastructure.Services
{
    public class KeywordService : IKeywordService
    {
        private readonly IKeywordRepository _keywordRepository;

        public KeywordService(IKeywordRepository keywordRepository)
        {
            _keywordRepository = keywordRepository;
        }

        public async Task<IEnumerable<string>?> GetAllKeywords()
        {
            var keywords = await _keywordRepository.GetAllAsync();
            if (keywords == null || !keywords.Any())
                return null;
            var response = keywords.Select(x => x.KeywordName);
            return response;
        }

        public async Task<bool> AddKeyword(string name)
        {
            var keyword = new Keyword
            {
                KeywordName = name
            };
            return await _keywordRepository.AddAsync(keyword);
        }
    }
}
