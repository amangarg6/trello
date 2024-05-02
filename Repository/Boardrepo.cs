using Microsoft.EntityFrameworkCore;
using trello.Data;
using trello.Models;
using trello.Repository.IRepository;

namespace trello.Repository
{
    public class Boardrepo:IBoardrepo
    {
        private readonly ApplicationDbcontext _context;
        public Boardrepo(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<Board> CreateBoard(Board Board)
        {
            var data = await _context.boards.AddAsync(Board);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<bool> DeleteBoard(Board Board)
        {
            _context.boards.Remove(Board);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Board>> GetBoard()
        {
            return await _context.boards.ToListAsync();
        }

        public async Task<Board> GetBoard(int BoardId)
        {
            return await _context.boards.FindAsync(BoardId);
        }

        public async Task<Board> GetBoardDetailsByIdAsync(string boardId)
        {
            if (!int.TryParse(boardId,out int boardIdInt))
            {
                return null;
            }
            var BoardDetails = await _context.boards
                .FirstOrDefaultAsync(c => c.Id == boardIdInt);

                if (BoardDetails == null)
                {

                   return null;
                }
            var Board = new Board
            {
             Id = BoardDetails.Id,
             Title = BoardDetails.Title,
             visibility = BoardDetails.visibility,
   
            };
            return Board;
        }

     


        public async Task<bool> GetBoardExists(int BoardId)
        {
            return await _context.boards.AnyAsync(e => e.Id == BoardId);
        }

        public async Task<bool> GetBoardExists(string BoardName)
        {
            return await _context.boards.AnyAsync(e => e.Title == BoardName);
        }

  
        public async Task<bool> save()
        {
            return await _context.SaveChangesAsync() == 1 ? true : false;
        }

        public Task<bool> UpdateBoard(Board Board)
        {
            _context.boards.Update(Board);
            return save();
        }
    }
}
