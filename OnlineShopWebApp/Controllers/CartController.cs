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
        public IActionResult Index(int id)
        {
            foreach (var cart in HomeController.Carts)
                if (cart.Id == id)
                    if(cart.Items.Count > 0)
                        return View(cart);
                    else
                        return View((object)null);
            return View((object)null);
        }

        public IActionResult Add(int productId)
        {
            var product = HomeController.Products.TryGetElementById(productId);
            var cart = HomeController.Carts.TryGetElementById(0);
            cart.Add(product);
            return RedirectToAction("Index", 0);
        }
    }
}
