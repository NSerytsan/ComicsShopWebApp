using System.ComponentModel.DataAnnotations.Schema;
namespace ComicsShopWebApp.Models
{
    [Table("Order")]
    public class Order
    {
        public Order()
        {
            ProductItems = new HashSet<ProductItem>();
        }
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        
        public DateTime OrderDate { get; set; }
        public string DeliveryAdress { get; set; } = null!;
        public int PaymentStatus { get; set; }
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public Status Status { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<ProductItem> ProductItems { get; set; } = null!;
    }
}
