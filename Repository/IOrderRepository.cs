using Backend.Models;

namespace Backend.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetByCostumerAsync(int customerId);
        Task<IEnumerable<Order>> GetByMerchantAsync(int merchantId);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
     }
 }