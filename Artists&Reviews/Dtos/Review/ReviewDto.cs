namespace Artists_Reviews.Dtos.Review
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int? ArtistId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool? IsDeleted { get; set; } = false;
        public DateTime Createdon { get; set; } = DateTime.Now;
    }
}
