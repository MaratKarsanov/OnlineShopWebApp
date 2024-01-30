using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CalculatorController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string Index(double a, double b, string operation)
        {
            if (operation is null || operation == "+")
                return a + " + " + b + " = " + (a + b);
            if (operation == "-")
                return a + " - " + b + " = " + (a - b);
            if (operation == "*")
                return a + " * " + b + " = " + (a * b);
            return "Неверная операция. Можно использовать только \"+\", \"-\", \"*\"!";
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
