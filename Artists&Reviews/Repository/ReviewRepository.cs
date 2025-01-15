using Artists_Reviews.Data;
using Artists_Reviews.Interface;
using Artists_Reviews.Models;
using Microsoft.EntityFrameworkCore;

namespace Artists_Reviews.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDBContext _context;
        public ReviewRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Review> CreateAsync(Review reviewModel)
        {
            await _context.Reviews.AddAsync(reviewModel);
            await _context.SaveChangesAsync();

            return reviewModel;
        }

        public async Task<Review?> DeleteAsync(int id)
        {
            var reviewModel = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);
            if (reviewModel == null)
            {
                return null;
            }

            _context.Reviews.Remove(reviewModel);
            await _context.SaveChangesAsync();
            return reviewModel;

        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Review?> UpdateAsync(int id, Review reviewModel)
        {
            var existingReview = await _context.Reviews.FindAsync(id);
            if (existingReview == null)
            {
                return null;
            }

            existingReview.Rating = reviewModel.Rating;
            existingReview.IsDeleted = false;
            existingReview.Comment = reviewModel.Comment;

            await _context.SaveChangesAsync();

            return existingReview;
        }
    }
}
