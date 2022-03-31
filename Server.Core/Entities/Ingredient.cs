using server.Units;
using Server.Common;
using System.Collections.Generic;

namespace server.Models
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }   
        public int PurchaseQuantity { get; set; }
        public float PurchasePrice { get; set; }
        public UnitEnum PurchaseUnit { get; set; }   
        public List<RecipeIngredients> RecipeIngredients { get; set; }
        
    }
}
