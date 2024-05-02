using trello.Models;

namespace trello.Repository.IRepository
{
    public interface IDescriptionrepo
    {
        Task<ICollection<NewDescription>> GetDescription();
        Task<NewDescription> GetDescription(int DescriptionId);
        Task<bool> GetDescriptionExists(int DescriptionId);
        Task<bool> GetDescriptionExists(string DescriptionName);
        Task<NewDescription> CreateDescription(NewDescription Description);
        Task<bool> save();
        Task<List<NewDescription>> GetDescriptionBycardId(int cardId);
    }
}
