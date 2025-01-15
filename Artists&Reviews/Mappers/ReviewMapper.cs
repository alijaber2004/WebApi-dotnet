using System.Runtime.CompilerServices;
using Artists_Reviews.Dtos.Review;
using Artists_Reviews.Models;

namespace Artists_Reviews.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewDto ToReviewDto(this Review reviewModel)
        {
            return new ReviewDto
            {
                Id = reviewModel.Id,
                ArtistId = reviewModel.ArtistId,
                Comment = reviewModel.Comment,
                IsDeleted = reviewModel.IsDeleted,
                Createdon = reviewModel.Createdon,
                Rating = reviewModel.Rating
            };
        }
        public static Review ToReviewFromCreate(this CreateReviewDto reviewDto, int artistId)
        {
            return new Review
            {
                ArtistId = artistId,
                Comment = reviewDto.Comment,
                IsDeleted = reviewDto.IsDeleted,
                Rating = reviewDto.Rating
            };
        }

        public static Review ToReviewFromUpdate(this UpdateReviewDto reviewDto)
        {
            return new Review
            {
                Comment = reviewDto.Comment,
                IsDeleted = reviewDto.IsDeleted,
                Rating = reviewDto.Rating
            };
        }
    }
}
