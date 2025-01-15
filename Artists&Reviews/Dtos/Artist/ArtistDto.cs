using Artists_Reviews.Dtos.Review;

namespace Artists_Reviews.Dtos.Artist
{
    public class ArtistDto
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
        public List<ReviewDto> Reviews {  get; set; }
    }
}
