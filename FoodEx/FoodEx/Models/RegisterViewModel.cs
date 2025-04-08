using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FoodEx.Models
{
    public class RegisterViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string SelectedRole { get; set; }

        public List<SelectListItem> AvailableRoles { get; set; } = new List<SelectListItem>
        {
           new SelectListItem("User", "User"),
           new SelectListItem("Restaurant", "Restaurant"),
            new SelectListItem("DeliveryGuy", "DeliveryGuy")
        };


    }
}
