﻿using Microsoft.AspNetCore.Mvc;
using FridgeHandler.Data.Models;
using FridgeHandler.Services.Interface;

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
            return Ok(await _foodItemService.GetAllItemsAsync());
        }
    }
}