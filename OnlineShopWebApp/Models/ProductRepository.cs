using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class ProductRepository : IEnumerable<Product>
    {
        private List<Product> Products;

        public ProductRepository()
        {
            Products = new List<Product>();
        }

        public ProductRepository(List<Product> products)
        {
            Products = products;
        }

        public Product TryGetProductById(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            if (TryGetProductById(product.Id) is null)
                Products.Add(product);
            else
                throw new ArgumentException("Товар с таким id уже есть в репозитории!");
        }

        public IEnumerator<Product> GetEnumerator()
        {
            foreach (var product in Products)
                yield return product;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
