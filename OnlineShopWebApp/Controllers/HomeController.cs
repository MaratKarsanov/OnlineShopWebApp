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
        public static Repository<Product> Products { get; private set; } = new Repository<Product>(new List<Product>
        {
            new Product("Name1", 10000),
            new Product("Name2", 20000),
            new Product("Name3", 30000),
            new Product("Name4", 40000),
            new Product("Name5", 50000),
        });
        public static Repository<Cart> Carts { get; private set; } = new Repository<Cart>(new List<Cart>
        {
            new Cart(Constants.UserId)
        });

        public int CurrentUserId = 0;
 
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
