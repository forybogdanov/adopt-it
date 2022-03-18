using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class UserDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
       public DbSet<Post> Posts { get; set; }
        public DbSet<Animal> Animals { get; set; }

        public UserDbContext(DbContextOptions options): base(options)
        {
        }


    }
}
