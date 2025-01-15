namespace Artists_Reviews.Dtos.Artist
{
    public class UpdateArtistDto
    {
        public int Position { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
    }
}
