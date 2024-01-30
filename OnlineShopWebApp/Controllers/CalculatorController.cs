﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CalculatorController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string Index(double a, double b)
        {
            var result = a + b;
            return a + " + " + b + " = " + result;
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
