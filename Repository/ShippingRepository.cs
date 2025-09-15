using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class ShippingRepository:IShippingRepository
    {
        private readonly AppDBContext context;
        public ShippingRepository(AppDBContext context)
        {
            this.context = context;
         }

        public async Task<IEnumerable<Shipping>> GetAllAsync()
        {
            return await context.Shippings.Include(s=>s.Order).ToListAsync();
        }

        public async Task<Shipping> GetByIdAsync(int id)
        {
            return await context.Shippings.Include(s => s.Order).FirstOrDefaultAsync(s => s.Shipping_ID == id);
        }

        public async Task AddAsync(Shipping shipping)
        {
            context.Shippings.Add(shipping);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shipping shipping)
        {
            context.Shippings.Update(shipping);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var shipping = await context.Shippings.FindAsync(id);
            if (shipping != null)
            {
                context.Shippings.Remove(shipping);
                await context.SaveChangesAsync();
             }
        }

    }
 }