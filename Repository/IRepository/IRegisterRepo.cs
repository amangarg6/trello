using trello.Models;

namespace trello.Repository.IRepository
{
    public interface IRegisterRepo
    {
       
        ICollection<Register> GetUser();      
        bool Save();
        bool IsUniqueUser(string username);
        Register Authenticate(string username, string password);
        Register Register(Register userDetail);
        Register GetUser(int userid);
    }
}
