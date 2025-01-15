﻿namespace Artists_Reviews.Dtos.Review
{
    public class CreateReviewDto
    {
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool? IsDeleted { get; set; } = false;
    }
}
