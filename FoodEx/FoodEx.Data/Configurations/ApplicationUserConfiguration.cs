using FoodEx.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodEx.Data.Constants;

namespace FoodEx.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = Constants.Constants.ApplicationUserConsants.AdminId,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@foodex.com",
                    NormalizedEmail = "ADMIN@FOODEX.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!")
                },
                new ApplicationUser
                {
                    Id = Constants.Constants.ApplicationUserConsants.UserId,
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@foodex.com",
                    NormalizedEmail = "USER@FOODEX.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User123!")
                },
                new ApplicationUser
                {
                    Id = Constants.Constants.ApplicationUserConsants.DeliveryGuyId,
                    UserName = "deliveryguy",
                    NormalizedUserName = "DELIVERYGUY",
                    Email = "deliveryguy@foodex.com",
                    NormalizedEmail = "DELIVERYGUY@FOODEX.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Delivery123!")
                },
                new ApplicationUser
                {
                    Id = Constants.Constants.ApplicationUserConsants.RestaurantId,
                    UserName = "restaurantowner",
                    NormalizedUserName = "RESTAURANTOWNER",
                    Email = "restaurantowner@foodex.com",
                    NormalizedEmail = "RESTAURANTOWNER@FOODEX.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Restaurant123!"),
                },
                new ApplicationUser
                {
                    Id = "restaurant-owner-2",
                    UserName = "pizzalover",
                    NormalizedUserName = "PIZZALOVER",
                    Email = "pizzalover@foodex.com",
                    NormalizedEmail = "PIZZALOVER@FOODEX.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Pizza123!"),
                },
                new ApplicationUser
                {
                    Id = "restaurant-owner-3",
                    UserName = "burgerboss",
                    NormalizedUserName = "BURGERBOSS",
                    Email = "burgerboss@foodex.com",
                    NormalizedEmail = "BURGERBOSS@FOODEX.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Burger123!"),
                }
            );
        }
    }
}
