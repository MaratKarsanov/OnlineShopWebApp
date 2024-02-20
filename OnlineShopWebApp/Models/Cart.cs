using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Cart : IEnumerable<CartItem>, IReposytoryItem
    {
        //private Dictionary<Product, int> Products;
        public List<CartItem> Items;
        public int Id { get; }
        public string UserId { get; }
        public decimal TotalCost 
        { 
            get
            {
                return Items
                    .Sum(i => i.TotalCost);
            }
        }

        public Cart(string userId = "UnknownUser")
        {
            UserId = userId;
            //Products = new Dictionary<Product, int>();
            Items = new List<CartItem>();
        }

        public Cart(string userId, IEnumerable<Product> products) : this(userId)
        {
            foreach (var product in products)
                Add(product);
        }

        public void Add(Product product)
        {
            foreach (var item in Items)
                if (item.Product == product)
                {
                    item.Amount++;
                    return;
                }
            Items.Add(new CartItem(1, product));
            Items = Items
                .OrderBy(i => i.TotalCost)
                .ToList();
        }

        //public void Remove(Product product)
        //{
        //    if (Products.ContainsKey(product))
        //    {
        //        Products.Remove(product);
        //        TotalCost -= product.Cost;
        //    }
        //}

        public static bool operator ==(Cart c1, Cart c2)
        {
            return c1.Id == c2.Id;
        }

        public static bool operator !=(Cart c1, Cart c2)
        {
            return c1.Id != c2.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Cart))
                return false;
            var objAsCart = (Cart)obj;
            return this == objAsCart;
        }

        public IEnumerator<CartItem> GetEnumerator()
        {
            foreach (var item in Items)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
