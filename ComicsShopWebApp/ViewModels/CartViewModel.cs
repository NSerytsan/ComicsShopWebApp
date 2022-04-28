using ComicsShopWebApp.Models;

namespace ComicsShopWebApp.ViewModels
{
    public class CartViewModel
    {
        public IList<ProductItem> Items { get; set; } = new List<ProductItem>();
        public decimal Total { get; set; }
    }
}
