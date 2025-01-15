namespace Artists_Reviews.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int? ArtistId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool ? IsDeleted { get; set; } = false;
        public DateTime Createdon { get; set; } = DateTime.Now;
        public Artist? Artist { get; set; }

    }
}
