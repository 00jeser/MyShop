using Microsoft.EntityFrameworkCore;
using MyShop.Shared;

namespace MyShop.Server.DB
{
    public class ProductsDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
