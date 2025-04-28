using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodEx.Data.Entity; // assuming Rating is here

namespace FoodEx.Data.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Food)
                .WithMany()
                .HasForeignKey(r => r.FoodId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
