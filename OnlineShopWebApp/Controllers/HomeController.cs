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
        private readonly IRepository<Product> Products;
        private readonly IRepository<Cart> Carts;

        public int CurrentUserId = 0;
 
        public HomeController(ILogger<HomeController> logger, 
            IRepository<Product> products,
            IRepository<Cart> carts)
        {
            for (var i = 1; i < 6; i++)
                products.Add(new Product("Name" + i, i * 10000));
            carts.Add(new Cart(Constants.UserId));
            Products = products;
            Carts = carts;
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
