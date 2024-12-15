using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodEx.Entity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure Orders -> User relationship
            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Orders -> DeliveryGuy relationship
            builder.Entity<Order>()
                .HasOne(o => o.DeliveryGuy)
                .WithMany()
                .HasForeignKey(o => o.DeliveryGuyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Other relationships
            builder.Entity<Restaurant>()
                .HasMany(r => r.Foods)
                .WithOne(f => f.Restaurant)
                .HasForeignKey(f => f.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasOne(o => o.Restaurant)
                .WithMany()
                .HasForeignKey(o => o.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasOne(o => o.DeliveryAddress)
                .WithMany()
                .HasForeignKey(o => o.DeliveryAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserFavorite>()
                .HasOne(uf => uf.User)
                .WithMany()
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserFavorite>()
                .HasOne(uf => uf.Restaurant)
                .WithMany()
                .HasForeignKey(uf => uf.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Rating>()
                .HasOne(r => r.Food)
                .WithMany()
                .HasForeignKey(r => r.FoodId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Address>()
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
