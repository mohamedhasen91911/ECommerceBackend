using Backend.Models;

namespace Backend.Repository
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetByProductAsync(int productId);
        Task<Review> GetByIdAsync(int id);
        Task AddAsync(Review review);
        Task UpdateAsync(Review review);
        Task DeleteAsync(int id);
     }
 }