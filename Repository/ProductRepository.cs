using System.Formats.Asn1;
using System.Linq.Expressions;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly AppDBContext context;
        public ProductRepository(AppDBContext context) { this.context = context; }


        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Products
                        .Include(p => p.Merchant)
                        .Include(p => p.Brand)
                        .Include(p => p.Category)
                        .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await context.Products
                        .Include(p => p.Merchant)
                        .Include(p => p.Brand)
                        .Include(p=>p.Category)
                        .FirstOrDefaultAsync(p=>p.Product_ID == id );
        }

        public async Task AddAsync(Product product)
        {
            context.Products.Add(product);
             await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
             }

        }

    }
 }