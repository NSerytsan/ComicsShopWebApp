using System.ComponentModel.DataAnnotations.Schema;

namespace ComicsShopWebApp.Models
{
    [Table("Status")]
    public class Status
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
    }
}