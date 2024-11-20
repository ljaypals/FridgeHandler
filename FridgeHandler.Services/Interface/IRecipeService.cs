using FridgeHandler.Data.Models;

namespace FridgeHandler.Services.Interface
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetRecipesByIngredientsAsync(IEnumerable<string> ingredients);
        Task<Recipe> AddRecipeAsync(Recipe recipe);
    }
}