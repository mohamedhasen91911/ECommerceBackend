using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
    public class ProductService
    {
        public readonly IProductRepository repo;
        public ProductService(IProductRepository repo) { this.repo = repo; }

        public async Task<IEnumerable<Product>> GetProducts() => await repo.GetAllAsync();
        public async Task<Product> GetProduct(int id) => await repo.GetByIdAsync(id);
        public async Task AddProduct(Product product) => await repo.AddAsync(product);
        public async Task UpdateProduct(Product product) => await repo.UpdateAsync(product);
        public async Task DeleteProduct(int id) => await repo.DeleteAsync(id);


    }
 }