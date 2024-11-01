using System.Text.Json.Serialization;

namespace PiecesOfArt_Application_Assignment.Models
{
    public class LoyaltyCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<User> Users { get; set; }
    }
}
