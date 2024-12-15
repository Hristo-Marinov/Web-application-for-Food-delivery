using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Data
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public int FoodId { get; set; }
        [ForeignKey("FoodId")]
        public Food Food { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; }
    }
}
