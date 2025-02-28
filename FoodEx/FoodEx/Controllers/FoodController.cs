using Microsoft.AspNetCore.Mvc;
using FoodEx.Entity.Context;
using System.Linq;

namespace FoodEx.Controllers
{
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult FoodDetails(int id)
        {
            var food = _context.Foods
                .Where(f => f.FoodId == id)
                .Select(f => new {
                    f.FoodId,
                    f.Name,
                    f.Description,
                    f.Price,
                    RestaurantName = f.Restaurant.Name
                }).FirstOrDefault();

            if (food == null)
            {
                return NotFound();
            }

            return View("~/Views/Food/FoodDetails.cshtml", food);
        }
    }
}
