using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class FeaturedRepository : IFeaturedRepository
    {
        private readonly AppDBContext context;
        public FeaturedRepository(AppDBContext context) { this.context = context; }

        public async Task<IEnumerable<FeaturedProduct>> GetAllAsync()
        {
            return await context.FeaturedProducts
                .Include(f => f.Product)
                .ToListAsync();
        }

        public async Task<FeaturedProduct> GetByIdAsync(int id)
        {
            return await context.FeaturedProducts
                .Include(f => f.Product)
                .FirstOrDefaultAsync(f => f.Featured_ID == id);
        }

        public async Task AddAsync(FeaturedProduct featured)
        {
            context.FeaturedProducts.Add(featured);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FeaturedProduct featured)
        {
            context.FeaturedProducts.Update(featured);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var f = await context.FeaturedProducts.FindAsync(id);
            if (f != null)
            {
                context.FeaturedProducts.Remove(f);
                await context.SaveChangesAsync();
            }
        }
    }
 }