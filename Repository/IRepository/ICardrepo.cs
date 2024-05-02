using trello.Models;

namespace trello.Repository.IRepository
{
    public interface ICardrepo
    {
        Task<ICollection<Card>> GetCard();
        Task<Card> GetCard(int CardId);
        Task<bool> GetCardExists(int CardId);
        Task<bool> GetCardExists(string CardName);
        Task<Card> CreateCard(Card Card);
        Task<bool> save();
        Task<List<Card>> GetCardByListId(int listId);
        Task MoveCardToList(int cardId, int listId);
        Task<List> GetList(int ListId);
    }
}
