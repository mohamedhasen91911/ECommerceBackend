using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
    public class OrderService
    {
        public readonly IOrderRepository repo;
        public OrderService(IOrderRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Order>> GetOrders() => await repo.GetAllAsync();
        public async Task<Order> GetOrder(int id) => await repo.GetByIdAsync(id);
        public async Task<IEnumerable<Order>> GetCustomerOrders(int customerId) => await repo.GetByCostumerAsync(customerId);
        public async Task<IEnumerable<Order>> GetMerchantOrders(int merchantId) => await repo.GetByMerchantAsync(merchantId);
        public async Task AddOrder(Order order) => await repo.AddAsync(order);
        public async Task UpdateOrder(Order order) => await repo.UpdateAsync(order);
        public async Task DeleteOrder(int id) => await repo.DeleteAsync(id);
     }
 }