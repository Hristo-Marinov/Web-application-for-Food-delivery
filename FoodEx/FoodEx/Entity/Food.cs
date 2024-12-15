using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Entity
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
    }
}
