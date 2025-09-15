using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class StockHistoryRepository : IStockHistoryRepository
    {
    private readonly AppDBContext context;
    public StockHistoryRepository(AppDBContext context) { this.context = context; }

    public async Task<IEnumerable<StockHistory>> GetAllAsync()
    {
        return await context.StockHistories
            .Include(h => h.Product)
            .ToListAsync();
    }

    public async Task<IEnumerable<StockHistory>> GetByProductIdAsync(int productId)
    {
        return await context.StockHistories
            .Include(h => h.Product)
            .Where(h => h.Product_ID == productId)
            .ToListAsync();
    }

    public async Task AddAsync(StockHistory history)
    {
        context.StockHistories.Add(history);
        await context.SaveChangesAsync();
    }
    }

 }