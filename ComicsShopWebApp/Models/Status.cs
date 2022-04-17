namespace ComicsShopWebApp.Models
{
    public partial class Status
    {
        public Status()
        {
            OrderOrderStatusNavigations = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
        public bool StatusType { get; set; }
        public bool AccessOrderCancel { get; set; }

        public virtual ICollection<Order> OrderOrderStatusNavigations { get; set; }

    }
}
