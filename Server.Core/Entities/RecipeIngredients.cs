using server.Units;
using System;

namespace server.Models
{
    public class RecipeIngredients
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int Quantity { get; set; }
        public UnitEnum Unit { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
