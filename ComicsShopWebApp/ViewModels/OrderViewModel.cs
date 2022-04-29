using ComicsShopWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ComicsShopWebApp.ViewModels
{
    public class OrderViewModel
    {
        public IList<ProductItem> Items { get; set; } = new List<ProductItem>();
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Адреса")]
        public string DeliveryAddress { get; set; } = string.Empty;
    }
}
