using PiecesOfArt_Application_Assignment.Dto;
using PiecesOfArt_Application_Assignment.Models;

namespace PiecesOfArt_Application_Assignment.Repos
{
    public interface ILoyaltyCardRepo
    {
        LoyaltyCard? Get(int id);
        List<LoyaltyCard> GetAll();
        void Add(LoyaltyCard_Dto user);
        void Update(LoyaltyCard_Dto user, int id);
        void Delete(int id);
    }
}
