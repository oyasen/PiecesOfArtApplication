using PiecesOfArt_Application_Assignment.Models;
using PiecesOfArt_Application_Assignment.Dto;

namespace PiecesOfArt_Application_Assignment.Repos
{
    public interface ICategoryRepo
    {
        Category? Get(int id);
        List<Category> GetAll();
        void Add(Category_Dto Category);
        void Update(Category_Dto Category,int id);
        void Delete(int id);
    }
}
