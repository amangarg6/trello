using trello.Models;

namespace trello.Repository.IRepository
{
    public interface IListrepo
    {
        Task<ICollection<List>> GetList();
        Task<List> GetList(int ListId);
        Task<bool> GetListExists(int ListId);
        Task<bool> GetListExists(string ListName);
        Task<List> CreateList(List List);
        Task<bool> save();
        Task<List<List>> GetListByBoardId(int boardId);
    }
}
