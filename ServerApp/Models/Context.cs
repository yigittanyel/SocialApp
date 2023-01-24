using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace serverapp.Models
{
    public class Context : IdentityDbContext<User,Role,int>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public Context()
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
