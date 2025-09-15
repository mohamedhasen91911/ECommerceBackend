using Backend.Models;

namespace Backend.Repository
{
    public interface ICartRepository
    {
        Task<ShoppingCart> GetCartByUserIdAsync(int userId);
        Task AddItemAsync(int userId, CartItem item);
        Task RemoveItemAsync(int userId, int cartItemId);
        Task ClearCartAsync(int userId);
     }
 }