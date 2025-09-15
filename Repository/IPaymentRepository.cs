using Backend.Models;

namespace Backend.Repository
{
    public interface IPaymentRepository
    {
        Task<Payment> GetByIdAsync(int id);
        Task<Payment> GetByOrderIdAsync(int orderId);
        Task AddAsync(Payment payment);
        
     }
 }