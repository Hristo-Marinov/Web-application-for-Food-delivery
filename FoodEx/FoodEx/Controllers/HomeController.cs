using Microsoft.AspNetCore.Mvc;
using FoodEx.Entity.Context;
using System.Linq;

namespace FoodEx.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.RestaurantCount = _context.Restaurants.Count();
            ViewBag.FoodCount = _context.Foods.Count();
            ViewBag.DeliveryGuyCount = _context.Users
                .Where(u => _context.UserRoles
                    .Where(ur => ur.RoleId == _context.Roles.FirstOrDefault(r => r.Name == "DeliveryGuy").Id)
                    .Select(ur => ur.UserId)
                    .Contains(u.Id))
                .Count();

            var restaurants = _context.Restaurants.ToList();
            return View(restaurants);
        }

        public IActionResult TRF()
        {
            var restaurants = _context.Restaurants.ToList();
            return View("TRF", restaurants);
        }

        public IActionResult Place()
        {
            var restaurants = _context.Restaurants.ToList();
            return View();
        }
    }
}