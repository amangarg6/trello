using Microsoft.EntityFrameworkCore;
using trello.Data;
using trello.Models;
using trello.Repository.IRepository;

namespace trello.Repository
{
    public class Cardrepo:ICardrepo
    {
        private readonly ApplicationDbcontext _context;
        public Cardrepo(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<Card> CreateCard(Card Card)
        {
            var data = await _context.cards.AddAsync(Card);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<ICollection<Card>> GetCard()
        {
            return await _context.cards.ToListAsync();
        }

        public async Task<Card> GetCard(int CardId)
        {

            return await _context.cards.FindAsync(CardId);
        }

        async Task<List<Card>> ICardrepo.GetCardByListId(int listId)
        {
            return await _context.cards.Where(c => c.ListId == listId).ToListAsync();
        }

        public  async Task<bool> GetCardExists(int CardId)
        {
            return await _context.cards.AnyAsync(e => e.Id == CardId);
        }

        public async Task<bool> GetCardExists(string CardName)
        {
            return await _context.cards.AnyAsync(e => e.Text == CardName);
        }

        public async Task<bool> save()
        {
            return await _context.SaveChangesAsync() == 1 ? true : false;
        }

        public async Task MoveCardToList(int cardId, int listId)
        {
            var card = await _context.cards.FindAsync(cardId);
            if (card == null)
            {
                throw new InvalidOperationException("Card not found");
            }

            var lists = await GetList(listId);

            card.ListId = lists.Id; // Update the ListId property of the card

            await _context.SaveChangesAsync();
        }

        public async Task<List> GetList(int ListId)
        {
            return await _context.lists.FindAsync(ListId);
        }
    }
}
