using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
     public class WishlistService
    {
        private readonly IWishlistRepository repo;
        public WishlistService(IWishlistRepository repo) { this.repo = repo; }

        public async Task<Wishlist> GetWishlist(int userId) => await repo.GetWishlistByUserIdAsync(userId);
        public async Task AddItem(int userId, WishlistItem item) => await repo.AddItemAsync(userId, item);
        public async Task RemoveItem(int userId, int itemId) => await repo.RemoveItemAsync(userId, itemId);
        public async Task ClearWishlist(int userId) => await repo.ClearWishlistAsync(userId);
    }
 }