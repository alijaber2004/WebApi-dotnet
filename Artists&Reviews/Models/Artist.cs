
namespace Artists_Reviews.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty ;
        public List<Review> Reviews { get; set; } = new List<Review>();

    }
}
