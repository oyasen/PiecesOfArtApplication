using Microsoft.EntityFrameworkCore;
using PiecesOfArt_Application_Assignment.Data;
using PiecesOfArt_Application_Assignment.Dto;
using PiecesOfArt_Application_Assignment.Models;
using System.Security.AccessControl;

namespace PiecesOfArt_Application_Assignment.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicatioDbContext _context;
        public UserRepo(ApplicatioDbContext context)
        {
            _context = context;
        }
        public void Add(User_Dto user)
        {
            var u = new User
            {
                Age = user.Age,
                Email = user.Email,
                LoyaltyCardId = user.LoyaltyCardId,
                Name = user.Name,
            };
            _context.users.Add(u);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = Get(id);
            _context.users.Remove(user);
            _context.SaveChanges();
        }

        public User? Get(int id)
        {
            return _context.users
                .Include(u => u.LoyaltyCard)
                .Include(u => u.pieceOfArts)
                .ThenInclude(u=>u.Category)
                .FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            return _context.users
                .Include(u => u.LoyaltyCard)
                .Include(u => u.pieceOfArts)
                .ThenInclude(u => u.Category)
                .ToList();
        }

        public void Update(User_Dto user,int id)
        {
            var uther = Get(id);
            uther.Age = user.Age;
            uther.Email = user.Email;
            uther.LoyaltyCardId = user.LoyaltyCardId;
            uther.Name = user.Name;
            _context.users.Update(uther);
            _context.SaveChanges();
        }
    }
}
