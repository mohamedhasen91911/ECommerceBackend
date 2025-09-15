using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDBContext context;
        public CartRepository(AppDBContext context) { this.context = context; }

        public async Task<ShoppingCart> GetCartByUserIdAsync(int userId)
        {
           return await context.ShoppingCarts
                        .Include(c => c.CartItems)
                        .ThenInclude(ci => ci.Product)
                        .FirstOrDefaultAsync(c => c.User_ID == userId);
        }

        public async Task AddItemAsync(int userId, CartItem item)
        {
            var cart = await GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                cart = new ShoppingCart() { User_ID = userId };
                context.ShoppingCarts.Add(cart);
            }

            cart.CartItems.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task RemoveItemAsync(int userId, int cartItemId)
        {
            var cart = await GetCartByUserIdAsync(userId);
            var item = cart?.CartItems.FirstOrDefault(ci => ci.CartItem_ID == cartItemId);
            if (item != null)
            {
                context.CartItems.Remove(item);
                await context.SaveChangesAsync();
             }
        }
        public async Task ClearCartAsync(int userId)
        {
            var cart = await GetCartByUserIdAsync(userId);
            if (cart != null)
            {
                context.CartItems.RemoveRange(cart.CartItems);
                await context.SaveChangesAsync();
             }
        }

    }
 }