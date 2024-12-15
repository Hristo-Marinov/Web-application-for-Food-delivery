using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Entity
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string OwnerUserId { get; set; }
        [ForeignKey("OwnerUserId")]
        public ApplicationUser Owner { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public ICollection<Food> Foods { get; set; }
        public ICollection<ApplicationUser> DeliveryGuys { get; set; }
    }
}
