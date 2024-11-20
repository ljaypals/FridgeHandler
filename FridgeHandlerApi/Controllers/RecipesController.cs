using FridgeHandler.Services;
using FridgeHandler.Data.Models;
using FridgeHandler.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FridgeHandlerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes([FromQuery] IEnumerable<string> ingredients)
        {
            var recipes = await _recipeService.GetRecipesByIngredientsAsync(ingredients);
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> AddRecipe(Recipe recipe)
        {
            var newRecipe = await _recipeService.AddRecipeAsync(recipe);
            return CreatedAtAction(nameof(GetRecipes), new { id = newRecipe.Id }, newRecipe);
        }
    }
}