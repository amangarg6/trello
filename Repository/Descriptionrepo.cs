using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using trello.Data;
using trello.Models;
using trello.Repository.IRepository;

namespace trello.Repository
{
    public class Descriptionrepo:IDescriptionrepo
    {
        private readonly ApplicationDbcontext _context;
        public Descriptionrepo(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<NewDescription> CreateDescription(NewDescription Description)
        {
            var data = await _context.newDescriptions.AddAsync(Description);
            await _context.SaveChangesAsync();
            return data.Entity; 
        }

        public async Task<ICollection<NewDescription>> GetDescription()
        {
            return await _context.newDescriptions.ToListAsync();
        }

        public async Task<NewDescription> GetDescription(int DescriptionId)
        {
            return await _context.newDescriptions.FindAsync(DescriptionId);
        }

        async Task<List<NewDescription>> IDescriptionrepo.GetDescriptionBycardId(int cardId)
        {
            return await _context.newDescriptions.Where(l => l.CardId == cardId).ToListAsync();
        }

        public async Task<bool> GetDescriptionExists(int DescriptionId)
        {
            return await _context.newDescriptions.AnyAsync(e => e.Id == DescriptionId);
        }

        public async Task<bool> GetDescriptionExists(string DescriptionName)
        {
            return await _context.newDescriptions.AnyAsync(e => e.Description == DescriptionName);
        }

        public async Task<bool> save()
        {
            return await _context.SaveChangesAsync() == 1 ? true : false;
        }
    }
}
