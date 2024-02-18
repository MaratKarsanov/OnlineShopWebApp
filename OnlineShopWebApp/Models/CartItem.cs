namespace OnlineShopWebApp.Models
{
    public class CartItem
    {
        private static int instanceCounter = 0;
        public int Id { get; }
        public int Amount { get; set; }
        public Product Product { get; }
        public decimal TotalCost
        {
            get
            {
                return Product.Cost * Amount;
            }
        }

        public CartItem(int amount, Product product)
        {
            Id = instanceCounter;
            instanceCounter++;
            Amount = amount;
            Product = product;
        }
    }
}
