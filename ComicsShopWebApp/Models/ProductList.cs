namespace ComicsShopWebApp.Models
{
    public partial class ProductList
    {
        public ProductList()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
