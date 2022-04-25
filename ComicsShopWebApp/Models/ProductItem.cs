namespace ComicsShopWebApp.Models
{
    public class ProductItem
    {
        public int Id { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }

        public Order Order { get; set; } = null!;
    }
}
