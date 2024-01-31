﻿namespace OnlineShopWebApp.Models
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }

        public Product(int id, string name, int cost, string description = "")
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
        }

    }
}
