using System.ComponentModel.DataAnnotations.Schema;
namespace ComicsShopWebApp.Models
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int ProductListId { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAdress { get; set; } = null!;
        public int OrderStatus { get; set; }
        public int PaymentStatus { get; set; }
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ProductList ProductList { get; set; } = null!;
    }
}
