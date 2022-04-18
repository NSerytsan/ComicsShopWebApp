using System.ComponentModel.DataAnnotations.Schema;

namespace ComicsShopWebApp.Models
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
