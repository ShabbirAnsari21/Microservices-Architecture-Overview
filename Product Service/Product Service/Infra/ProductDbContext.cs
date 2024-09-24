using Microsoft.EntityFrameworkCore;
using Product_Service.Entity;

namespace Product_Service.Infra
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> ProductTbl { get; set; }
    }

}
