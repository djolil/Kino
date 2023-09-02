namespace Kino.Core.Interfaces.Service
{
    public interface IKeywordService
    {
        public Task<IEnumerable<string>?> GetAllKeywords();
        public Task<bool> AddKeyword(string name);
    }
}
