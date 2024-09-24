using Microsoft.EntityFrameworkCore;
using Order_Service.Entity;

namespace Order_Service.Infra
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Order> OrderTbl { get; set; }
    }
}
