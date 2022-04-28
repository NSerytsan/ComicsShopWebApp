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
        public virtual DbSet<ProductItem> ProductItems { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, StatusName = "CART" },
                new Status { Id = 2, StatusName = "Новий" },
                new Status { Id = 3, StatusName = "Обробляється менеджером" },
                new Status { Id = 4, StatusName = "Дані підтверджені" },
                new Status { Id = 5, StatusName = "Очікує відправки" },
                new Status { Id = 6, StatusName = "Передано до служби доставки" },
                new Status { Id = 7, StatusName = "Доставляється" },
                new Status { Id = 8, StatusName = "Замовлення отримано" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Манхви", CategoryDescription = "Корейські кольорові комікси" },
                new Category { Id = 2, CategoryName = "Манга", CategoryDescription = "Японські чорно-білі комікси" },
                new Category { Id = 3, CategoryName = "Журнали", CategoryDescription = "Журнали зарубіжних видань" },
                new Category { Id = 4, CategoryName = "Аксесуари", CategoryDescription = "Аксесуари з вашими улюбленими героями" },
                new Category { Id = 5, CategoryName = "Новели", CategoryDescription = "Новели азійських авторів" },
                new Category { Id = 6, CategoryName = "Продукція англійською" },
                new Category { Id = 7, CategoryName = "Продукція українською" },
                new Category { Id = 8, CategoryName = "Продукція японською" },
                new Category { Id = 9, CategoryName = "У жорсткій обкладинці" },
                new Category { Id = 10, CategoryName = "У м'якій обкладинці" },
                new Category { Id = 11, CategoryName = "Комікси" }
                );

            modelBuilder.Entity<Product>().Navigation(p => p.Categories).AutoInclude();
            modelBuilder.Entity<Order>().Navigation(o => o.ProductItems).AutoInclude();
            modelBuilder.Entity<Order>().Navigation(o => o.Status).AutoInclude();
            modelBuilder.Entity<ProductItem>().Navigation(p => p.Product).AutoInclude();
        }

    }
}
