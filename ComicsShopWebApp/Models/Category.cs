using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicsShopWebApp.Models
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Назва Категорії\" має бути заповнене")]
        [Display(Name = ("Назва Категорії"))]
        public string CategoryName { get; set; } = null!;

        [Display(Name = ("Опис категорії"))]
        public string? CategoryDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
