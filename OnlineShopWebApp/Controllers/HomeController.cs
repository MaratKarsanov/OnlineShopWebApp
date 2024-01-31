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
        public static ProductRepository Products { get; private set; }

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
                result.Add(new Product("Name_" + (i + 1), rnd.Next(100, 10000)));
            }
            return result;
        }

        public string Index()
        {
            //var products = MakeListProducts(5);
            var result = new StringBuilder();
            foreach (var product in Products)
                result.Append(product.ToString() + "\n\n");
            return result.ToString();
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
