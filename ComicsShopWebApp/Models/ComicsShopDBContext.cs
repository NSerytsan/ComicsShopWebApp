using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComicsShopWebApp.Models
{
    public class ComicsShopDBContext : IdentityDbContext<User>
    {
        public ComicsShopDBContext(DbContextOptions<ComicsShopDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<User> AppUsers { get; set; } = null!;
        public virtual DbSet<UserSupport> UserSupports { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductList> ProductLists { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

        
    }


}
