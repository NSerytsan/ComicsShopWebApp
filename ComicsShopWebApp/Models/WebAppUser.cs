using Microsoft.AspNetCore.Identity;

namespace ComicsShopWebApp.Models
{
    public class WebAppUser : IdentityUser
    {
        public virtual Client Client { get; set; } = null!;
    }
}
