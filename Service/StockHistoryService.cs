using Backend.Models;
using Backend.Repository;

namespace Backend.Service
{
        public class StockHistoryService
    {
        private readonly IStockHistoryRepository repo;
        public StockHistoryService(IStockHistoryRepository repo) { this.repo = repo; }

        public async Task<IEnumerable<StockHistory>> GetAll() => await repo.GetAllAsync();
        public async Task<IEnumerable<StockHistory>> GetByProductId(int productId) => await repo.GetByProductIdAsync(productId);
        public async Task Add(StockHistory history) => await repo.AddAsync(history);
    }

 }