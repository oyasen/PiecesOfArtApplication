using PiecesOfArt_Application_Assignment.Models;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace PiecesOfArt_Application_Assignment.Dto
{
    public class PieceOfArt_Dto
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public DateOnly PublicatioDate { get; set; }
        public int? UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
