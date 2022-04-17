namespace ComicsShopWebApp.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientSupports = new HashSet<ClientSupport>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string FullName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ClientPassword { get; set; } = null!;
        public string? DefaultDeliveryAdress { get; set; }

        public virtual ICollection<ClientSupport> ClientSupports { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public virtual WebAppUser WebAppUser { get; set; }
    }
}
