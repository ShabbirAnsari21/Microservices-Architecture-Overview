using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using User_Service.Entity;

namespace User_Service.Infra
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> UserTbl { get; set; }
    }
}
