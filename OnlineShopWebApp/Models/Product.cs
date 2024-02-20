using System;

namespace OnlineShopWebApp.Models
{
    public class Product : IReposytoryItem
    {
        private static int instanceCounter = 0;   
        public int Id { get; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string PictureLink { get; }   
        public Product(string name = "UnknownProduct", 
            decimal cost = 0, 
            string description = "", 
            string pictureLink = "/Images/DefaultImg.jpg")
        {
            Id = instanceCounter;
            Name = name;
            Cost = cost;
            Description = description;
            PictureLink = pictureLink;
            instanceCounter++;
        }

        public override string ToString()
        {
            //return Id + "\n" + Name + "\n" + Cost + "\n" + Description;
            return $"{Id}\n{Name}\n{Cost}";
        }

        public static bool operator ==(Product p1, Product p2)
        {
            return p1.Id == p2.Id;
        }

        public static bool operator !=(Product p1, Product p2)
        {
            return p1.Id != p2.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Product))
                return false;
            var objAsProduct = (Product)obj;
            return this == objAsProduct;
        }
    }
}
