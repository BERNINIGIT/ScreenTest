using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScreenTest.Models;
using ScreenTest.Services.Contracts;
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
        private readonly ICasing _casing;

        public HomeController(ILogger<HomeController> logger, FoodContext foodContext, ICasing casing)
        {
            _logger = logger;
            _foodContext = foodContext;
            _casing = casing;
        }
        public IActionResult Index(string customCase = "NoCasing")
        {
            List<string> dishes = _foodContext.Dishes.Select( s => s.DishName).ToList();
            
            dishes = dishes.Select(x => _casing.ChangeCasing(x, customCase)).ToList();
            
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
