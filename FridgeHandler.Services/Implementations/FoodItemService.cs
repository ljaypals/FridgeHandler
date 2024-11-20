using FridgeHandler.Data;
using FridgeHandler.Data.Models;
using FridgeHandler.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FridgeHandler.Services.Implementations
{
    public class FoodItemService : IFoodItemService
    {
        private readonly AppDbContext _context;

        public FoodItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FoodItem>> GetAllItemsAsync()
        {
            return await _context.FoodItems.ToListAsync();
        }

        public async Task<FoodItem> AddItemAsync(FoodItem item)
        {
            _context.FoodItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<FoodItem>> GetExpiringItemsAsync()
        {
            var now = DateTime.UtcNow;
            return await _context.FoodItems
                .Where(item => item.ExpiryDate <= now.AddDays(3))
                .ToListAsync();
        }
    }
}