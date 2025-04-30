using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodEx.Data.Entity;
using System.Reflection.Emit;

namespace FoodEx.Data.Configurations
{
    public class FoodCategoryConfiguration : IEntityTypeConfiguration<FoodCategory>
    {
        public void Configure(EntityTypeBuilder<FoodCategory> builder)
        {
            builder
            .HasKey(fc => new { fc.FoodId, fc.CategoryId });  

            builder
                .HasOne(fc => fc.Food)
                .WithMany(f => f.FoodCategories)
                .HasForeignKey(fc => fc.FoodId);

            builder
                .HasOne(fc => fc.Category)
                .WithMany(c => c.FoodCategories)
                .HasForeignKey(fc => fc.CategoryId);

            builder.HasData(
            new FoodCategory { FoodId = 1, CategoryId = 2 },
            new FoodCategory { FoodId = 2, CategoryId = 4 },
            new FoodCategory { FoodId = 3, CategoryId = 3 },
            new FoodCategory { FoodId = 4, CategoryId = 2 },
            new FoodCategory { FoodId = 5, CategoryId = 2 },
            new FoodCategory { FoodId = 6, CategoryId = 1 },
            new FoodCategory { FoodId = 7, CategoryId = 1 }
            );

        }
    }
}
