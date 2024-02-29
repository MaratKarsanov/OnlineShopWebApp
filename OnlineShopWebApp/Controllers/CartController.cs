using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepository<Product> Products;
        private readonly IRepository<Cart> Carts;

        public CartController(IRepository<Product> products, IRepository<Cart> carts)
        {
            Products = products;
            Carts = carts;
        }

        public IActionResult Index(int id)
        {
            foreach (var cart in Carts)
                if (cart.Id == id)
                    if(cart.Items.Count > 0)
                        return View(cart);
                    else
                        return View((object)null);
            return View((object)null);
        }

        public IActionResult Add(int productId)
        {
            var product = Products.TryGetElementById(productId);
            var cart = Carts.TryGetElementById(0);
            cart.Add(product);
            return RedirectToAction("Index", 0);
        }
    }
}
