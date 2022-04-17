namespace ComicsShopWebApplication.Models
{
    public partial class ClientSupport
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string? TextMessage { get; set; }

        public virtual Client Client { get; set; } = null!;
    }
}
