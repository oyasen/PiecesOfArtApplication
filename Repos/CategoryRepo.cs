using Microsoft.EntityFrameworkCore;
using PiecesOfArt_Application_Assignment.Data;
using PiecesOfArt_Application_Assignment.Dto;
using PiecesOfArt_Application_Assignment.Models;
using System.Security.AccessControl;

namespace PiecesOfArt_Application_Assignment.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicatioDbContext _context;
        public CategoryRepo(ApplicatioDbContext context)
        {
            _context = context;
        }
        public void Add(Category_Dto Category)
        {
            var u = new Category
            {
                Description = Category.Description,
                Name = Category.Name,
            };
            _context.categories.Add(u);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var Category = Get(id);
            _context.categories.Remove(Category);
            _context.SaveChanges();
        }

        public Category? Get(int id)
        {
            return _context.categories.FirstOrDefault(u => u.Id == id);
        }

        public List<Category> GetAll()
        {
            return _context.categories.ToList();
        }

        public void Update(Category_Dto Category,int id)
        {
            var uther = Get(id);
            uther.Description = Category.Description;
            uther.Name = Category.Name;
           
            _context.categories.Update(uther);
            _context.SaveChanges();
        }
    }
}
