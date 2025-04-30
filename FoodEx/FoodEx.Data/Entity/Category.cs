using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Data.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        
        public ICollection<FoodCategory> FoodCategories { get; set; } = new List<FoodCategory>();
    }
}
