using Backend.Models;

namespace Backend.Repository
{
    public interface IMerchantRepository
    {

        Task<IEnumerable<User>> GetAllMerchantsAsync();
        Task<User> GetMerchantByIdAsync(int id);
        Task AddAsync(User merchant);
        Task UpdateAsync(User merchant);
        Task DeleteAsync(int id);
     }
 }