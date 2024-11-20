using FridgeHandler.Data;
using FridgeHandler.Data.Models;
using FridgeHandler.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FridgeHandler.Services.Implementations
{
    public class RecipeService : IRecipeService
    {
        private readonly AppDbContext _context;

        public RecipeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetRecipesByIngredientsAsync(IEnumerable<string> ingredients)
        {
            return await _context.Recipes
                .Where(recipe => ingredients.All(ingredient => recipe.Ingredients.Contains(ingredient)))
                .ToListAsync();
        }

        public async Task<Recipe> AddRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }
    }
}