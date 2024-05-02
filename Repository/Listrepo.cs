using Microsoft.EntityFrameworkCore;
using trello.Data;
using trello.Models;
using trello.Repository.IRepository;

namespace trello.Repository
{
    public class Listrepo:IListrepo
    {
        private readonly ApplicationDbcontext _context;
        public Listrepo(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<List> CreateList(List List)
        {
            var data = await _context.lists.AddAsync(List);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<ICollection<List>> GetList()
        {
            return await _context.lists.ToListAsync();
        }

        public async Task<List> GetList(int ListId)
        {

            return await _context.lists.FindAsync(ListId);
        }

        async Task<List<List>> IListrepo.GetListByBoardId(int boardId)
        {
            return await _context.lists.Where(l => l.BoardId == boardId).ToListAsync();
        }

        public async Task<bool> GetListExists(int ListId)
        {
            return await _context.lists.AnyAsync(e => e.Id == ListId);
        }

        public async Task<bool> GetListExists(string ListName)
        {
            return await _context.lists.AnyAsync(e => e.Title == ListName);
        }

        public async Task<bool> save()
        {
            return await _context.SaveChangesAsync() == 1 ? true : false;
        }
    }
}
