using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
     public class WishlistRepository : IWishlistRepository
    {
        private readonly AppDBContext context;
        public WishlistRepository(AppDBContext context) { this.context = context; }

        public async Task<Wishlist> GetWishlistByUserIdAsync(int userId)
        {
            return await context.Wishlists
                .Include(w => w.WishlistItems)
                .ThenInclude(wi => wi.Product)
                .FirstOrDefaultAsync(w => w.User_ID == userId);
        }

        public async Task AddItemAsync(int userId, WishlistItem item)
        {
            var wishlist = await GetWishlistByUserIdAsync(userId);
            if (wishlist == null)
            {
                wishlist = new Wishlist { User_ID = userId };
                context.Wishlists.Add(wishlist);
            }

            wishlist.WishlistItems.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task RemoveItemAsync(int userId, int wishlistItemId)
        {
            var wishlist = await GetWishlistByUserIdAsync(userId);
            var item = wishlist?.WishlistItems.FirstOrDefault(wi => wi.WishlistItem_ID == wishlistItemId);
            if (item != null)
            {
                context.WishlistItems.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task ClearWishlistAsync(int userId)
        {
            var wishlist = await GetWishlistByUserIdAsync(userId);
            if (wishlist != null)
            {
                context.WishlistItems.RemoveRange(wishlist.WishlistItems);
                await context.SaveChangesAsync();
            }
        }
    }
 }