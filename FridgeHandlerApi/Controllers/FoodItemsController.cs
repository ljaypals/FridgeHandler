using FridgeHandler.Services;
using FridgeHandler.Data.Models;
using FridgeHandler.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FridgeHandlerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly IFoodItemService _foodItemService;

        public FoodItemsController(IFoodItemService foodItemService)
        {
            _foodItemService = foodItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems()
        {
            var items = await _foodItemService.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<FoodItem>> AddFoodItem(FoodItem item)
        {
            var newItem = await _foodItemService.AddItemAsync(item);
            return CreatedAtAction(nameof(GetFoodItems), new { id = newItem.Id }, newItem);
        }

        [HttpGet("expiring")]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetExpiringItems()
        {
            var items = await _foodItemService.GetExpiringItemsAsync();
            return Ok(items);
        }
    }
}