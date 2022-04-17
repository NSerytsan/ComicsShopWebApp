using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComicsShopWebApp.Models
{
    public class ComicsShopDBContext : IdentityDbContext<WebAppUser>
    {
        public ComicsShopDBContext(DbContextOptions<ComicsShopDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
