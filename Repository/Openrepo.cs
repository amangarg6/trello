using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using trello.Data;
using trello.Models;
using trello.Repository.IRepository;

namespace trello.Repository
{
    public class Openrepo:IOpenrepo
    {
        private readonly ApplicationDbcontext _context;
        public Openrepo(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<Open> CreateOpen(Open Open)
        {
            var data = await _context.opens.AddAsync(Open);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<ICollection<Open>> GetOpen()
        {
            return await _context.opens.ToListAsync();
        }

        public async Task<Open> GetOpen(int OpenId)
        {
            return await _context.opens.FindAsync(OpenId);
        }

        async Task<List<Open>> IOpenrepo.GetOpenByCardId(int cardId)
        {
            return await _context.opens.Where(l => l.CardId == cardId).ToListAsync();
        }

        public async Task<bool> GetOpenExists(int OpenId)
        {
            return await _context.opens.AnyAsync(e => e.Id == OpenId);
        }

        public async Task<bool> GetOpenExists(string OpenName)
        {
            return await _context.opens.AnyAsync(e => e.Comment == OpenName);
        }

        public async Task<bool> save()
        {
            return await _context.SaveChangesAsync() == 1 ? true : false;
        }
    }
}
