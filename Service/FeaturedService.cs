using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
    public class FeaturedService
    {
        private readonly IFeaturedRepository repo;
        public FeaturedService(IFeaturedRepository repo) { this.repo = repo; }

        public async Task<IEnumerable<FeaturedProduct>> GetAll() => await repo.GetAllAsync();
        public async Task<FeaturedProduct> Get(int id) => await repo.GetByIdAsync(id);
        public async Task Add(FeaturedProduct featured) => await repo.AddAsync(featured);
        public async Task Update(FeaturedProduct featured) => await repo.UpdateAsync(featured);
        public async Task Delete(int id) => await repo.DeleteAsync(id);
    }
 }