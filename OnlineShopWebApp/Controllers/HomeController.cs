using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static ProductRepository Products { get; private set; } = new ProductRepository(new List<Product>
        {
            new Product("Name1", 10000),
            new Product("Name2", 20000),
            new Product("Name3", 30000),
            new Product("Name4", 40000),
            new Product("Name5", 50000),
        });

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            if (Products is null || Products.Count == 0)
                Products = new ProductRepository(MakeListProducts(5));
        }

        private List<Product> MakeListProducts(int count)
        {
            var result = new List<Product>();
            var rnd = new Random();
            for (var i = 0; i < count; i++)
            {
                result.Add(new Product("Name_" + (i + 1), rnd.Next(10, 100) * 1000));
            }
            return result;
        }

        public IActionResult Index()
        {
            return View(Products);
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
