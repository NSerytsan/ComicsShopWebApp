using ComicsShopWebApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicsShopWebApp.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Назва продукту")]
        public string ProductName { get; set; } = null!;

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Ціна")]
        [Column(TypeName = "money")]
        [Range(1, 1000000)]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Залишилося")]
        [Range(0, 1000000)]
        public int NumLeft { get; set; }
        public IEnumerable<Category> categories { get; set; }
    }
}
