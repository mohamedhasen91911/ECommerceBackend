using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
    public class ShippingService
    {
        private readonly IShippingRepository repo;
        public ShippingService(IShippingRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Shipping>> GetShippings() => await repo.GetAllAsync();
        public async Task<Shipping> GetShipping(int id) => await repo.GetByIdAsync(id);
        public async Task AddShipping(Shipping shipping) => await repo.AddAsync(shipping);
        public async Task UpdateShipping(Shipping shipping) => await repo.UpdateAsync(shipping);
        public async Task DeleteShipping(int id) => await repo.DeleteAsync(id);
     }
 }