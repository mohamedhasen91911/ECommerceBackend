using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDBContext context;
        public ReviewRepository(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Review>> GetByProductAsync(int productId)
        {
            return await context.Reviews
                                .Where(r => r.Product_ID == productId)
                                .Include(r => r.Customer)
                                .Include(r => r.Product)
                                .ToListAsync();
        }
        public async Task<Review> GetByIdAsync(int id)
        {
            return await context.Reviews
                        .Include(r => r.Customer)
                        .Include(r => r.Product)
                        .FirstOrDefaultAsync(r => r.Review_ID == id);
        }

        public async Task AddAsync(Review review)
        {
            context.Reviews.Add(review);
            await context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Review review)
        {
            context.Reviews.Update(review);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var review = await context.Reviews.FindAsync(id);
            if (review != null)
            {
                context.Reviews.Remove(review);
                await context.SaveChangesAsync();
             }
        }
    }
 }