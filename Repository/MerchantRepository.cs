using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly AppDBContext context;
        public MerchantRepository(AppDBContext context) { this.context = context; }

        public async Task<IEnumerable<User>> GetAllMerchantsAsync()
        {
            return await context.Users
                        .Where(u => u.Role == "Merchant")
                        .ToListAsync();
        }

        public async Task<User> GetMerchantByIdAsync(int id)
        {
            return await context.Users
                        .FirstOrDefaultAsync(u => u.User_ID == id && u.Role == "Merchant");
        }

        public async Task UpdateAsync(User merchant)
        {
            context.Users.Update(merchant);
            await context.SaveChangesAsync();
        }
        public async Task AddAsync(User merchant)
        {
            context.Users.Add(merchant);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var merchant = await GetMerchantByIdAsync(id);
            if (merchant != null)
            {
                context.Users.Remove(merchant);
                await context.SaveChangesAsync();
             }
        }


    }
 }