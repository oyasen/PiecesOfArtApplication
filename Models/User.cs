using System.Text.Json.Serialization;

namespace PiecesOfArt_Application_Assignment.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public List<PieceOfArt> pieceOfArts { get; set; }
        public int LoyaltyCardId { get; set; }
        public LoyaltyCard LoyaltyCard { get; set; }
    }
}
