using FoodEx.Data;
using FoodEx.Data.Entity;
using FoodEx.Data.Entity.Context;
using FoodEx.Entity;
using FoodEx.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FoodEx.Services
{
    public class FoodService : IFoodService
    {
        private readonly ApplicationDbContext _context;

        public FoodService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FoodViewModel> GetFoodDetailsAsync(int foodId)
        {
            var food = await _context.Foods
                .Where(f => f.FoodId == foodId)
                .Select(f => new FoodViewModel
                {
                    FoodId = f.FoodId,
                    Name = f.Name,
                    Description = f.Description,
                    Price = f.Price,
                    RestaurantName = f.Restaurant.Name,
                    ImageUrl = f.ImageUrl,
                    AverageRating = _context.Ratings.Where(r => r.FoodId == f.FoodId).Any()
                        ? _context.Ratings.Where(r => r.FoodId == f.FoodId).Average(r => r.RatingValue)
                        : 0,
                    Comments = _context.Ratings
                        .Where(r => r.FoodId == f.FoodId && !string.IsNullOrEmpty(r.Comment))
                        .Select(r => new CommentViewModel
                        {
                            UserId = r.UserId,
                            Comment = r.Comment,
                            RatingValue = r.RatingValue
                        }).ToList()
                })
                .FirstOrDefaultAsync();

            return food;
        }

        public async Task AddToCartAsync(string userId, int foodId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var existingItem = cart.Items.FirstOrDefault(ci => ci.FoodId == foodId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Items.Add(new CartItem { FoodId = foodId, Quantity = 1 });
            }

            await _context.SaveChangesAsync();
        }

        public async Task SubmitRatingAsync(int foodId, string userId, int ratingValue, string comment)
        {
            var existingRating = await _context.Ratings
                .FirstOrDefaultAsync(r => r.FoodId == foodId && r.UserId == userId);

            if (existingRating != null)
            {
                existingRating.RatingValue = ratingValue;
                existingRating.Comment = comment;
            }
            else
            {
                var rating = new Rating
                {
                    FoodId = foodId,
                    UserId = userId,
                    RatingValue = ratingValue,
                    Comment = comment
                };

                _context.Ratings.Add(rating);
            }

            await _context.SaveChangesAsync();
        }
    }
}
