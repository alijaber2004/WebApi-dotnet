using Artists_Reviews.Models;

namespace Artists_Reviews.Interface
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllAsync();

        Task<Review?> GetByIdAsync(int id);
        Task<Review> CreateAsync(Review reviewModel);
        Task<Review?> UpdateAsync(int id, Review reviewModel);
        Task<Review?> DeleteAsync(int id);
    }
}
