using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodEx.Entity;

namespace FoodEx.Data.Entity
{
    public class UserFavorite
    {
        [Key]
        public int FavoriteId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }
    }
}
