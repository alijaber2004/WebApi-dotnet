namespace Artists_Reviews.Dtos.Artist
{
    public class CreateArtistDto
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
    }
}
