using Microsoft.AspNetCore.Mvc;
using FoodEx.Entity.Context;
using System.Linq;

namespace FoodEx.Controllers
{
    public class PlaceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Place()
        {
            var restaurants = _context.Restaurants.ToList();
            return View(restaurants);
        }

        public IActionResult Details(int id)
        {
            var place = _context.Restaurants
                .Where(r => r.RestaurantId == id)
                .Select(r => new {
                    r.RestaurantId,
                    r.Name,
                    r.Location,
                    Foods = r.Foods.ToList()
                }).FirstOrDefault();

            if (place == null)
            {
                return NotFound();
            }

            return View("PlaceDetails", place);
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

            return View("FoodDetails", food);
        }
    }
}
