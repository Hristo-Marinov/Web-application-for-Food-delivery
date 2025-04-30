using FoodEx.Data.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Burger",
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Pizza"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Dessert"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Pasta"
                }
            );
        }
    }
}
