using trello.Models;

namespace trello.Repository.IRepository
{
    public interface IBoardrepo
    {
        Task<ICollection<Board>> GetBoard();
        Task<Board> GetBoard(int BoardId);
        Task<bool> GetBoardExists(int BoardId);
        Task<bool> GetBoardExists(string BoardName);
        Task<Board> CreateBoard(Board Board);
        Task<bool> UpdateBoard(Board Board);
        Task<bool> DeleteBoard(Board Board);
        Task<bool> save();
        Task<Board> GetBoardDetailsByIdAsync(string boardId);
    }
}
