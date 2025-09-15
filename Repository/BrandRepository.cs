using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{

    public class BrandRepository:IBrandRepository
    {
        private readonly AppDBContext context;
        public BrandRepository(AppDBContext context) { this.context = context; }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await context.Brands.ToListAsync();
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            return await context.Brands.FindAsync(id);
        }

        public async Task AddAsync(Brand brand)
        {
            context.Brands.Add(brand);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Brand brand)
        {
            context.Brands.Update(brand);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await context.Brands.FindAsync(id);
            if (brand != null)
            {
                context.Brands.Remove(brand);
                await context.SaveChangesAsync();
             }
        }


    }
 }