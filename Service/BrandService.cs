using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
    public class BrandService
    {
        private readonly IBrandRepository repo;
        public BrandService(IBrandRepository repo) { this.repo = repo; }

        public async Task<IEnumerable<Brand>> GetBrands() => await repo.GetAllAsync();
        public async Task<Brand> GetBrand(int id) => await repo.GetByIdAsync(id);
        public async Task AddBrand(Brand brand) => await repo.AddAsync(brand);
        public async Task UpdateBrand(Brand brand) => await repo.UpdateAsync(brand);
        public async Task DeleteBrand(int id) => await repo.DeleteAsync(id);

     }
 }