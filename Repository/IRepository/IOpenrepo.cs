using trello.Models;

namespace trello.Repository.IRepository
{
    public interface IOpenrepo
    {
        Task<ICollection<Open>> GetOpen();
        Task<Open> GetOpen(int OpenId);
        Task<bool> GetOpenExists(int OpenId);
        Task<bool> GetOpenExists(string OpenName);
        Task<Open> CreateOpen(Open Open);
        Task<bool> save();
        Task<List<Open>> GetOpenByCardId(int cardId);
    }
}
