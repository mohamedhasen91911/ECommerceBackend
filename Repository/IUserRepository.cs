using Backend.Models;

namespace Backend.Repository
{
    public interface IUserReposiroty
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
     }
 }