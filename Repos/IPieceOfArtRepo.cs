using PiecesOfArt_Application_Assignment.Models;
using PiecesOfArt_Application_Assignment.Dto;

namespace PiecesOfArt_Application_Assignment.Repos
{
    public interface IPieceOfArtRepo
    {
        PieceOfArt? Get(int id);
        List<PieceOfArt> GetAll();
        void Add(PieceOfArt_Dto PieceOfArt);
        void Update(PieceOfArt_Dto PieceOfArt,int id);
        void Delete(int id);
    }
}
