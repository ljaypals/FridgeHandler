﻿namespace FridgeHandler.Data.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; } = new(); // Stored as comma-separated values in DB
        public string Instructions { get; set; }
    }
}