using FoodEx.Entity;

namespace FoodEx.Data.Entity
{
    public class OrderAssignment
    {
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public string? DeliveryGuyId { get; set; }
        public ApplicationUser? DeliveryGuy { get; set; }

        public int? DeliveryAddressId { get; set; }
        public Address? DeliveryAddress { get; set; }

    }
}
