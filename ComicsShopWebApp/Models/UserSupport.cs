using System.ComponentModel.DataAnnotations.Schema;

namespace ComicsShopWebApp.Models
{
    [Table("UserSupport")]
    public class UserSupport
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string? TextMessage { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
