using Microsoft.EntityFrameworkCore;
using PiecesOfArt_Application_Assignment.Models;

namespace PiecesOfArt_Application_Assignment.Data
{
    public class ApplicatioDbContext : DbContext
    {
        public ApplicatioDbContext(DbContextOptions<ApplicatioDbContext> options) : base(options) { }
        public DbSet<Category> categories { get; set; }
        public DbSet<PieceOfArt> pieceOfArts { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<LoyaltyCard> loyaltyCards { get; set; }
    }
}
        //<3