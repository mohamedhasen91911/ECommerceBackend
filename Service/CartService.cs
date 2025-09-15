using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
    public class CartService
    {
        private readonly ICartRepository repo;
        public CartService(ICartRepository repo) { this.repo = repo; }

        public async Task<ShoppingCart> GetCart(int userId) => await repo.GetCartByUserIdAsync(userId);
        public async Task AddItem(int userId, CartItem item) => await repo.AddItemAsync(userId, item);
        public async Task RemoveItem(int userId, int cartItemId) => await repo.RemoveItemAsync(userId, cartItemId);
        public async Task ClearCart(int userId) => await repo.ClearCartAsync(userId);
        
     }
}