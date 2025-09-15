using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
    public class MerchantService
    {
        private readonly IUserReposiroty userRepo;
        public MerchantService(IUserReposiroty userRepo) { this.userRepo = userRepo; }

        public async Task<IEnumerable<User>> GetMerchants()
        {
            var users = await userRepo.GetAllAsync();
            return users.Where(u => u.Role == "Merchant");

         }
        public async Task<User> GetMerchant(int id)
        {
            var user = await userRepo.GetByIdAsync(id);
            return user?.Role == "Merchant" ? user : null;

         }

        public async Task AddMerchant(User merchant)
        {
            merchant.Role = "Merchant";
            await userRepo.AddAsync(merchant);

         }
        public async Task UpdateMerchant(User merchant)
        {
            merchant.Role = "Merchant";
            await userRepo.UpdateAsync(merchant);
         }
        public async Task DeleteMerchant(int id)
        {
            await userRepo.DeleteAsync(id);
         }


     }
 }