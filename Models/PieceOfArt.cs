using System.ComponentModel;
using System.Text.Json.Serialization;

namespace PiecesOfArt_Application_Assignment.Models
{
    public class PieceOfArt
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double  Price { get; set; }
        public DateOnly PublicatioDate { get; set; }
        public int? UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
