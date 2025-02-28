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