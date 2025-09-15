using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private AppDBContext context;
        public PaymentRepository(AppDBContext context)
        {
            this.context = context;
        }


        public async Task<Payment> GetByIdAsync(int id)
        {
            return await context.Payments.FirstOrDefaultAsync(p => p.Payment_ID == id);
        }

        public async Task<Payment> GetByOrderIdAsync(int orderId)
        {
            return await context.Payments.FirstOrDefaultAsync(p => p.Order_ID == orderId);
        }
        public async Task AddAsync(Payment payment)
        {
            context.Payments.Add(payment);
            await context.SaveChangesAsync();
        }

    }
 }