using Microsoft.EntityFrameworkCore;

namespace PetStore.data
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }

        public string DbPath { get; }

        public ProductContext()
        {
            var path = Directory.GetCurrentDirectory();
            DbPath = Path.Join(path, "products.db");
        }

            // The following configures EF to create a Sqlite database file in the
               // special "local" folder for your platform.
             protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
