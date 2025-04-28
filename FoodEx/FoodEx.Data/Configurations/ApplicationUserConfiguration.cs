using FoodEx.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                    Id = "admin-user-id",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@foodex.com",
                    NormalizedEmail = "ADMIN@FOODEX.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!")
                },
                new ApplicationUser
                {
                    Id = "regular-user-id",
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@foodex.com",
                    NormalizedEmail = "USER@FOODEX.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User123!")
                },
                new ApplicationUser
                {
                    Id = "deliveryguy-user-id",
                    UserName = "deliveryguy",
                    NormalizedUserName = "DELIVERYGUY",
                    Email = "deliveryguy@foodex.com",
                    NormalizedEmail = "DELIVERYGUY@FOODEX.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Delivery123!")
                },
                new ApplicationUser
                {
                    Id = "restaurant-user-id",
                    UserName = "restaurantowner",
                    NormalizedUserName = "RESTAURANTOWNER",
                    Email = "restaurantowner@foodex.com",
                    NormalizedEmail = "RESTAURANTOWNER@FOODEX.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Restaurant123!")
                }
            );
        }
    }
}
