namespace ComicsShopWebApp.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public bool IsChecked { get; set; }
    }
}
