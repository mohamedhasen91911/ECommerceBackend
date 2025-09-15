using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
    public class CategoryService
    {
        private readonly ICategoryRepository repo;
        public CategoryService(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Category>> GetCategories() => await repo.GetAllAsync();
        public async Task<Category> GetCategory(int id) => await repo.GetByIdAsync(id);
        public async Task AddCategory(Category category) => await repo.AddAsync(category);
        public async Task UpdateCategory(Category category) => await repo.UpdateAsync(category);
        public async Task DeleteCategory(int id) => await repo.DeleteAsync(id);
     }
 }