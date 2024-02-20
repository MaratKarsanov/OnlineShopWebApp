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
    public class ProductController : Controller
    {
        private readonly Repository<Product> Products;

        public ProductController(Repository<Product> products)
        {
            Products = products;
        }
        public IActionResult Index(int id)
        {
            foreach (var product in Products)
                if (product.Id == id)
                    return View(product);
            return View((object)null);

        }
    }
}
