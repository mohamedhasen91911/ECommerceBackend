using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
    public class ReviewService
    {
        private readonly IReviewRepository repo;
        public ReviewService(IReviewRepository repo) { this.repo = repo; }

        public async Task<IEnumerable<Review>> GetReviewsByProduct(int productId) => await repo.GetByProductAsync(productId);
        public async Task<Review> GetReview(int id) => await repo.GetByIdAsync(id);
        public async Task AddReview(Review review) => await repo.AddAsync(review);
        public async Task UpdateReview(Review review) => await repo.UpdateAsync(review);
        public async Task DeleteReview(int id) => await repo.DeleteAsync(id);
     }
 }