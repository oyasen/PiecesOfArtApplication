using Microsoft.EntityFrameworkCore;
using PiecesOfArt_Application_Assignment.Data;
using PiecesOfArt_Application_Assignment.Dto;
using PiecesOfArt_Application_Assignment.Models;
using System.Security.AccessControl;

namespace PiecesOfArt_Application_Assignment.Repos
{
    public class PieceOfArtRepo : IPieceOfArtRepo
    {
        private readonly ApplicatioDbContext _context;
        public PieceOfArtRepo(ApplicatioDbContext context)
        {
            _context = context;
        }
        public void Add(PieceOfArt_Dto PieceOfArt)
        {
            var u = new PieceOfArt
            {
                CategoryId = PieceOfArt.CategoryId,
                Price = PieceOfArt.Price,
                PublicatioDate = PieceOfArt.PublicatioDate,
                Title = PieceOfArt.Title,
                UserId = PieceOfArt.UserId,
            };
            _context.pieceOfArts.Add(u);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var PieceOfArt = Get(id);
            _context.pieceOfArts.Remove(PieceOfArt);
            _context.SaveChanges();
        }

        public PieceOfArt? Get(int id)
        {
            return _context.pieceOfArts
                .Include(u => u.Category)
                .FirstOrDefault(u => u.Id == id);
        }

        public List<PieceOfArt> GetAll()
        {
            return _context.pieceOfArts
                .Include(u => u.Category)
                .ToList();
        }

        public void Update(PieceOfArt_Dto PieceOfArt,int id)
        {
            var uther = Get(id);
            uther.CategoryId = PieceOfArt.CategoryId;
            uther.Price = PieceOfArt.Price;
            uther.PublicatioDate = PieceOfArt.PublicatioDate;
            uther.Title = PieceOfArt.Title;
            uther.UserId = PieceOfArt.UserId;
            _context.pieceOfArts.Update(uther);
            _context.SaveChanges();
        }
    }
}
