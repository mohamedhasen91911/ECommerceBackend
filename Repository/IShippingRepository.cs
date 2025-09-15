using Backend.Models;

namespace Backend.Repository
{
    public interface IShippingRepository
    {
        Task<IEnumerable<Shipping>> GetAllAsync();
        Task<Shipping> GetByIdAsync(int id);
        Task AddAsync(Shipping shipping);
        Task UpdateAsync(Shipping shipping);
        Task DeleteAsync(int id);
     }
 }