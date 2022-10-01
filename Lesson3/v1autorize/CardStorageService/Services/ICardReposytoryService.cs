using CardStorageService;

namespace CardStorageService.Services
{
    public interface ICardRepositoryService : IRepository<Card, string>
    {
        IList<Card> GetByClientId(int id);
    }
}
