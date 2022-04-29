namespace ComicsShopWebApp.Models
{
    public class ProductItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        
        public virtual Order Order { get; set; } = null!;
    }
}