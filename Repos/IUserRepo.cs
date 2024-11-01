using PiecesOfArt_Application_Assignment.Models;
using PiecesOfArt_Application_Assignment.Dto;

namespace PiecesOfArt_Application_Assignment.Repos
{
    public interface IUserRepo
    {
        User? Get(int id);
        List<User> GetAll();
        void Add(User_Dto user);
        void Update(User_Dto user,int id);
        void Delete(int id);
    }
}
