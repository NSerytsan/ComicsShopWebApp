using System.ComponentModel.DataAnnotations.Schema;

namespace ComicsShopWebApp.Models
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }

        public string CategoryName { get; set; } = null!;


        public string? CategoryDescription { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
