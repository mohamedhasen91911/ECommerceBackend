using Backend.Models;

namespace Backend.Repository
{
        public interface IFeaturedRepository
    {
        Task<IEnumerable<FeaturedProduct>> GetAllAsync();
        Task<FeaturedProduct> GetByIdAsync(int id);
        Task AddAsync(FeaturedProduct featured);
        Task UpdateAsync(FeaturedProduct featured);
        Task DeleteAsync(int id);
    }

 }