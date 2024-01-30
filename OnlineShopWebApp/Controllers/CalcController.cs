using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

namespace OnlineShopWebApp.Controllers
{
    public class CalcController : Controller
    {
        private readonly ILogger<CalcController> _logger;

        public CalcController(ILogger<CalcController> logger)
        {
            _logger = logger;
        }

        public string Index(double a, double b, string c)
        {
            if (c is null || c == "+")
                return a + " + " + b + " = " + (a + b);
            if (c == "-")
                return a + " - " + b + " = " + (a - b);
            if (c == "*")
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