namespace ComicsShopWebApplication.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductListId { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAdress { get; set; } = null!;
        public int OrderStatus { get; set; }
        public int PaymentStatus { get; set; }
        public decimal Cost { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual ProductList ProductList { get; set; } = null!;
    }
}
