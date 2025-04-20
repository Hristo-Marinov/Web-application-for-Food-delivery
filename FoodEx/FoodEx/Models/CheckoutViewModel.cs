using System.ComponentModel.DataAnnotations;

namespace FoodEx.Models
{
    public class CheckoutViewModel
    {
        [Required]
        [Display(Name = "Street Address")]
        public string Street { get; set; }

        [Display(Name = "City")]
        public string? City { get; set; }

        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }

        [Display(Name = "Country")]
        public string? Country { get; set; }
    }
}
