using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class StartController : Controller
    {
        private readonly ILogger<StartController> _logger;

        public StartController(ILogger<StartController> logger)
        {
            _logger = logger;
        }

        public string Hello()
        {
            var currentTime = DateTime.Now;
            if (currentTime.Hour >= 0 && currentTime.Hour < 6)
                return "Доброй ночи";
            if (currentTime.Hour >= 6 && currentTime.Hour < 12)
                return "Доброе утро";
            if (currentTime.Hour >= 12 && currentTime.Hour < 18)
                return "Добрый день";
            return "Добрый вечер";
        }

        public IActionResult Index()
        {
            return View();
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
