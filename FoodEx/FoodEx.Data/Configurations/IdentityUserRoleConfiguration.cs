using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodEx.Data.Configurations
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string> { UserId = "admin-user-id", RoleId = "1" },
                new IdentityUserRole<string> { UserId = "regular-user-id", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "deliveryguy-user-id", RoleId = "3" },
                new IdentityUserRole<string> { UserId = "restaurant-user-id", RoleId = "4" },
                new IdentityUserRole<string> { UserId = "restaurant-owner-3", RoleId = "4" },
                new IdentityUserRole<string> { UserId = "restaurant-owner-2", RoleId = "4" }
            );
        }
    }
}
