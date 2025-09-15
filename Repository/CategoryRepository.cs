using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly AppDBContext context;
        public CategoryRepository(AppDBContext context)
        {
            this.context = context;
         }


        public async Task<IEnumerable<Category>> GetAllAsync()
        {
           return  await context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id )
        {
            return await context.Categories.FindAsync(id);
        }
        public async Task AddAsync(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category != null)
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
             }
        }

    }
 }