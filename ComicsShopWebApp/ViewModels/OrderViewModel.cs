using ComicsShopWebApp.Models;

namespace ComicsShopWebApp.ViewModels
{
    public class OrderViewModel
    {
        public IList<ProductItem> Items { get; set; } = new List<ProductItem>();
        public decimal Total { get; set; }

        public string DeliveryAddress {get; set;} = string.Empty;
    }
}
