using Microsoft.EntityFrameworkCore;
using PiecesOfArt_Application_Assignment.Data;
using PiecesOfArt_Application_Assignment.Dto;
using PiecesOfArt_Application_Assignment.Models;
using System.Security.AccessControl;

namespace PiecesOfArt_Application_Assignment.Repos
{
    public class LoyaltyCardRepo : ILoyaltyCardRepo
    {
        private readonly ApplicatioDbContext _context;
        public LoyaltyCardRepo(ApplicatioDbContext context)
        {
            _context = context;
        }
        public void Add(LoyaltyCard_Dto LoyaltyCard)
        {
            var u = new LoyaltyCard
            {
                Description = LoyaltyCard.Description,
                Name = LoyaltyCard.Name,
            };
            _context.loyaltyCards.Add(u);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var LoyaltyCard = Get(id);
            _context.loyaltyCards.Remove(LoyaltyCard);
            _context.SaveChanges();
        }

        public LoyaltyCard? Get(int id)
        {
            return _context.loyaltyCards.FirstOrDefault(u => u.Id == id);
        }

        public List<LoyaltyCard> GetAll()
        {
            return _context.loyaltyCards.ToList();
        }

        public void Update(LoyaltyCard_Dto LoyaltyCard,int id)
        {
            var uther = Get(id);
            uther.Description = LoyaltyCard.Description;
            uther.Name = LoyaltyCard.Name;
            _context.loyaltyCards.Update(uther);
            _context.SaveChanges();
        }
    }
}
