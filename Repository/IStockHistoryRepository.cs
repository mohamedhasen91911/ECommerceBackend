using Backend.Models;

namespace Backend.Repository
{
    public interface IStockHistoryRepository
    {
    Task<IEnumerable<StockHistory>> GetAllAsync();
    Task<IEnumerable<StockHistory>> GetByProductIdAsync(int productId);
    Task AddAsync(StockHistory history);
    }

 }