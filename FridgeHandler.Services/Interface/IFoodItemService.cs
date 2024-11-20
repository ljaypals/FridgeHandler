using FridgeHandler.Data.Models;

namespace FridgeHandler.Services.Interface
{
    public interface IFoodItemService
    {
        Task<IEnumerable<FoodItem>> GetAllItemsAsync();
        Task<FoodItem> AddItemAsync(FoodItem item);
        Task<IEnumerable<FoodItem>> GetExpiringItemsAsync();
    }
}