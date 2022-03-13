using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        

    }
}
