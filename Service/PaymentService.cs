using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
    public class PaymentService
    {
        private readonly IPaymentRepository repo;
        public PaymentService(IPaymentRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Payment> GetPayment(int id) => await repo.GetByIdAsync(id);
        public async Task<Payment> GetPaymentByOrder(int orderId) => await repo.GetByOrderIdAsync(orderId);
        public async Task AddPayment(Payment payment) => await repo.AddAsync(payment);


    }
 }