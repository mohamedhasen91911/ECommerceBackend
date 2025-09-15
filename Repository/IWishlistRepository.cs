using Backend.Models;

namespace Backend.Repository
{
     public interface IWishlistRepository
    {
        Task<Wishlist> GetWishlistByUserIdAsync(int userId);
        Task AddItemAsync(int userId, WishlistItem item);
        Task RemoveItemAsync(int userId, int wishlistItemId);
        Task ClearWishlistAsync(int userId);
    }
 }