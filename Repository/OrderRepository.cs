using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly AppDBContext context;
        public OrderRepository(AppDBContext context)
        {
            this.context = context;
         }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await context.Orders
                        .Include(o => o.Customer)
                        .Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                        .Include(o => o.Payment)
                        .Include(o => o.Shipping)
                        .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await context.Orders
                        .Include(o => o.Customer)
                        .Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                        .Include(o => o.Payment)
                        .Include(o => o.Shipping)
                        .FirstOrDefaultAsync(o => o.Order_ID == id);
        }
        public async Task<IEnumerable<Order>> GetByCostumerAsync(int customerId)
        {
            return await context.Orders
                        .Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                        .Where(o => o.Customer_ID == customerId)
                        .ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetByMerchantAsync(int merchantId)
        {
            return await context.Orders
                        .Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                        .Where(o => o.OrderDetails.Any(od => od.Product.Merchant_ID == merchantId))
                        .ToListAsync();
        }
        public async Task AddAsync(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Order order)
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var order = await context.Orders.FindAsync(id);
            if (order == null)
            {
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
             }
        }



    }
 }