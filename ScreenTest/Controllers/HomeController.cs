using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScreenTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FoodContext _foodContext;

        public HomeController(ILogger<HomeController> logger, FoodContext foodContext)
        {
            _logger = logger;
            _foodContext = foodContext;
        }
        //[HttpPost]
        public IActionResult Index(string customCase = "NoCasing")
        {
            //List<string> dishes = new List<string>() { "Dish1", "Dish2"};
            List<string> dishes = _foodContext.Dishes.Select( s => s.DishName).ToList();
            if(customCase == "UpperCase")
                dishes = dishes.Select(x => x.ToUpperInvariant()).ToList();
            else if(customCase == "LowerCase")
                dishes = dishes.Select(x => x.ToLowerInvariant()).ToList();
            return View(dishes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
